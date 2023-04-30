using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance {get;private set;}

    [SerializeField]
    private string fileName;

    private FileDataHandler datahandler;


    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one data persistence manager");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        Debug.Log("Saved Money = " + gameData.moneyCount);

        // save data to file using data handler
        datahandler.Save(gameData);
        
    }

    public void LoadGame()
    {
        // load any saved data from file using data handler
        this.gameData = datahandler.Load();

        // if no data found, use new game values
        if (this.gameData == null)
        {
            Debug.Log("no data found");
            NewGame();
        }

        // push loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        Debug.Log("Loaded Money = " + gameData.moneyCount);
    }


    private void Start()
    {
        this.datahandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
