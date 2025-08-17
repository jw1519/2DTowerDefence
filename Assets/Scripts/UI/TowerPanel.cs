using UnityEngine;

public class TowerPanel : BasePanel
{
    public void CannonTower()
    {
        TowerBuildManager.instance.SetTowerTobuild("CannonTower");
    }
    public void ArcherTower()
    {
        TowerBuildManager.instance.SetTowerTobuild("ArcherTower");
    }
    public void MagicTower()
    {
        TowerBuildManager.instance.SetTowerTobuild("MagicTower");
    }
}
