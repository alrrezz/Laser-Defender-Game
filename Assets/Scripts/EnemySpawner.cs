using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
//--------------------------------------------- Variables ---------------------------------------------------
    [SerializeField] List<WaveConfig> waveConfigs;






//------------------------------------------ Start & Update -------------------------------------------------
    private IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }while (true);
    }






//---------------------------------------------- Methods ----------------------------------------------------
    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = 0; 
            waveIndex < waveConfigs.Count; 
            waveIndex++)
        {
            WaveConfig currentWave = 
                waveConfigs[waveIndex];

            yield return StartCoroutine
                (SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        for (int enemySpawned = 0; 
            enemySpawned < currentWave.GetNumberOfEnemies(); 
            enemySpawned++)
        {
            GameObject newEnemy = Instantiate
                (currentWave.GetEnemyPrefab(),
                currentWave.GetWayPoints()[0].transform.position,
                Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>()
                .SetWaveConfig(currentWave);

            yield return new WaitForSeconds
                (currentWave.GetTimeBetweenSpawns());
        }
    }

}
