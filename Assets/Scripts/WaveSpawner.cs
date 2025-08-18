using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int waveNumber = 0;
    public Transform spawnPoint;
    public Transform endPoint;


    IEnumerator SpawnWave()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(20f);
        waveNumber++;
    }
    public void SpawnEnemy()
    {

    }
}
