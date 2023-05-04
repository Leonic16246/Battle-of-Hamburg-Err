using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
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
        if (waveStartTimer <= 0)
        {
            StartCoroutine(WaveStart());
            waveStartTimer = waveInterval;

        }
        waveStartTimer -= Time.deltaTime;

        waveStartTimer = Mathf.Clamp(waveStartTimer, 0, Mathf.Infinity);

        waveCountdownText.text = Mathf.Floor(waveStartTimer).ToString();
    }

    IEnumerator WaveStart()
    {
        waveNumber++;
        waveCountText.text = "Wave: " + waveNumber.ToString();
        Debug.Log("wave "+ waveNumber + ": start");
        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
