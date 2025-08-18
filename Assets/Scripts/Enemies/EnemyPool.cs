using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;
    public List<GameObject> enemies;
    public int amountToPool;
    public Transform enemyParent;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> pooledDictionary;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject objectToPool;
        public int amountToPool = 100;
    }

    void Start()
    {
        pooledDictionary = new Dictionary<string, Queue<GameObject>>();

        Queue<GameObject> objectPool = new Queue<GameObject>();

        foreach (Pool pool in pools)
        {
            for (int i = 0; i < pool.amountToPool; i++)
            {
                GameObject obj = Instantiate(pool.objectToPool);
                obj.transform.SetParent(enemyParent);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            pooledDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnFromPoolEnemy(string tag, Vector3 position, Quaternion rotation)
    {
        if (pooledDictionary.ContainsKey(tag))
        {
            GameObject objectToSpawn = pooledDictionary[tag].Dequeue();
            if (!objectToSpawn.activeInHierarchy)
            {
                objectToSpawn.SetActive(true);

                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;

                pooledDictionary[tag].Enqueue(objectToSpawn);
                return objectToSpawn;
            }
            else
            {
                Debug.Log("Pool object not active " + tag);
                pooledDictionary[tag].Enqueue(objectToSpawn);
                return null;
            }
        }
        else
        {
            Debug.Log("Pool doesnt exist " + tag);
            return null;
        }
    }

}
