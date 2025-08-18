using UnityEngine;

public class ShootingTower : BaseTower, IShoot
{
    public Transform firePoint;
    public string enemyTag = "Enemy";
    public void Start()
    {
        InvokeRepeating("CheckForEnemies", 0, .5f);
    }
    private void Update()
    {
        if (target != null)
        {
            if (fireCountDown <= 0)
            {
                Shoot();
                fireCountDown = 1 / fireRate;
            }
        }
        fireCountDown -= Time.deltaTime;
    }
    public void CheckForEnemies()
    {
        //check if enemies are in range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // the distance between tower and enemy
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range) //if enemy is found within the range
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    public virtual void Shoot()
    {
        Vector3 distance = (target.transform.position - firePoint.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(distance);

        GameObject projectileGO = ProjectilePool.instance.SpawnFromPool("CannonBall", firePoint.position, Quaternion.identity);
        projectileGO.transform.rotation = rotation;
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.Seek(target);
        }
    }
}
