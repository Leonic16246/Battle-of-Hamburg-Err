using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float waveInterval = 5;
    private float waveStartTimer = 2;

    public TextMeshProUGUI waveNumberText;
    private int waveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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

        waveNumberText.text = Mathf.Floor(waveStartTimer).ToString();
    }

    IEnumerator WaveStart()
    {
        waveNumber++;
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
