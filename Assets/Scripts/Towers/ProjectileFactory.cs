using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : MonoBehaviour
{
    public static ProjectileFactory instance;
    public List<GameObject> projectiles;
    public GameObject CreateProjectile(string name)
    {
        GameObject instance = Instantiate(projectiles.Find(projectile => projectile.name == name));
        return instance;
    }
}
