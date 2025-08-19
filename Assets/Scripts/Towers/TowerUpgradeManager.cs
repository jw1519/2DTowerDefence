using UnityEngine;

public class TowerUpgradeManager : MonoBehaviour
{
    public void UpgradeFireRate(BaseTower tower)
    {
        if (tower != null)
        {
            tower.fireRate *= 2;
        }
    }
    public void UpgradeRange(BaseTower tower)
    {
        if (tower != null)
        {
            tower.fireRate *= 2;
        }
    }
    public void UpgradeDamage(BaseTower tower)
    {
        if (tower != null)
        {
            tower.fireRate *= 2;
        }
    }
}
