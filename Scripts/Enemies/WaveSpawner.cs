using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;
    public static bool StartingWave = false;

    public Wave[] waves;

    public Transform spawnPoint;
    public GameManager gameManager;
    public float spawnDelay = 10f;
    private float waweStarts = 5f;
    private int waveIndex = 0;
    public TextMeshProUGUI waveCountDownText;
 
    private void Awake() 
    {
        if(StartingWave == true)
        {
            StartingWave = false;
        }
    }



    private void Start()
    {
        EnemiesAlive = 0;
    }

    private void Update()
    {

        if(waveIndex == waves.Length && EnemiesAlive <= 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

            if (EnemiesAlive > 0)
            {
                return;
            }

        if (waweStarts <= 0)
        {
            StartCoroutine(SpawnWave());
            waweStarts = spawnDelay;
            return;
        }

        if(StartingWave)
        {
            waweStarts -= Time.deltaTime;

            waweStarts = Mathf.Clamp(waweStarts, 0f, Mathf.Infinity);

        }

        waveCountDownText.text = Mathf.Round(waweStarts).ToString();
       
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
         
        Wave wave = waves[waveIndex];

        EnemiesAlive += wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
