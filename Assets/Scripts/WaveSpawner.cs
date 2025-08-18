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
        SpawnEnemy(amount);
        yield return new WaitForSeconds(20f);
        waveNumber++;
    }
    public void SpawnEnemy(int amountToSpawn)
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
