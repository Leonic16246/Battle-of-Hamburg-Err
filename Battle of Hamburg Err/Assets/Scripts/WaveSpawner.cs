using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;

    public float waveInterval = 5;
    private float waveStartTimer = 2;

    public TextMeshProUGUI waveCountdownText, waveCountText;
    private int waveNumber = 0;
    ThemeSelecter themes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(passiveMe(1));
    }
    
 
    IEnumerator passiveMe(int secs)
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
            StartCoroutine(WaveStart());
            waveStartTimer = waveInterval;
            return;

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
