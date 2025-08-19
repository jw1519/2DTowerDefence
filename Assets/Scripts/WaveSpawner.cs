using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WaveSpawner : MonoBehaviour
{
    public int waveNumber = 0;
    public Transform spawnPoint;
    public Transform endPoint;
    public Transform enemyParent;


    public IEnumerator SpawnWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2f);
        }
        waveNumber++;
        yield return null;
    }
    public void SpawnEnemy()
    {
        GameObject spawnedEnemy = EnemyPool.instance.SpawnFromPoolEnemy("Enemy", spawnPoint.position, Quaternion.identity); //change for different enemies
        if (spawnedEnemy != null)
        {
            spawnedEnemy.GetComponent<NavMeshAgent>().enabled = true;
            spawnedEnemy.transform.SetParent(enemyParent);
            spawnedEnemy.GetComponent<BaseEnemy>().endLocation = endPoint;
        }
    }
}
