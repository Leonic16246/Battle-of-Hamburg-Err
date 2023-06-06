using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;

    public float waveInterval = 5;
    private float waveStartTimer = 5;

    public TextMeshProUGUI waveCountdownText, waveCountText;
    private int waveNumber = 1;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(passiveMe(3));
        EnemiesAlive = 0; // reset to 0 incase there were still enemies alive from a previous gamescene, otherwise update will keep returning
        
    }

    
 
    IEnumerator passiveMe(int secs) // find starting waypoint
 {
     yield return new WaitForSeconds(secs);
     spawnPoint = GameObject.Find("Waypoint (-1)").transform;
 }
 
    // Update is called once per frame
    void Update()
    {

        if(EnemiesAlive > 0)
        {
            return; 
        }
        
        if (waveStartTimer <= 0)
        {
            if (waveNumber == 31)
            {
                Time.timeScale = 0;
                gameOverScreen.SetActive(true);
                gameOverScreen.GetComponentInChildren<TextMeshProUGUI>().text = "Map completed";
            }
            else
            {
                StartCoroutine(WaveStart());
                waveStartTimer = waveInterval;
                return;
            }
        }
        waveStartTimer -= Time.deltaTime;

        waveStartTimer = Mathf.Clamp(waveStartTimer, 0, Mathf.Infinity);

        waveCountdownText.text = Mathf.Floor(waveStartTimer).ToString();
    }

    IEnumerator WaveStart()
    {
        waveCountText.text = "Wave: " + waveNumber.ToString();
        Debug.Log("wave "+ waveNumber + ": start");

        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count; i++)
        {
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/ wave.rate);
        }
        waveNumber++;
    }

    void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++; 
    }

}
