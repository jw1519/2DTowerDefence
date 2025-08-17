using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    public static TowerFactory instance;
    public List<GameObject> towers;
    public Color towerColor;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public GameObject CreateTower(string towerName)
    {
        GameObject instance = Instantiate(towers.Find(tower =>  tower.name == towerName));
        instance.name = towerName;
        instance.GetComponent<SpriteRenderer>().color = towerColor;
        return instance;
    }
}
