using UnityEngine;

public class PlayerStats : MonoBehaviour, IDataPersistence
{
    public static int Money;

    // placeholder
    void Start()
    {

    }

    public void SaveData(GameData data)
    {
        data.moneyCount = Money;
    }

    public void LoadData(GameData data)
    {
        Money = data.moneyCount;    
    }
}
