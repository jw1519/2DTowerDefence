
public class TowerPanel : BasePanel
{
    StatsPanel statsPanel;
    private void Start()
    {
        statsPanel = UIManager.instance.panels.Find(panel => panel.name == "StatsPanel").GetComponent<StatsPanel>();
    }
    public void CannonTower()
    {
        int cost = TowerFactory.instance.GetTowerToBuild("CannonTower").cost;

        if (statsPanel.CanBuy(cost))
        {
            TowerBuildManager.instance.SetTowerTobuild("CannonTower");
            statsPanel.RemoveGold(cost);
        }
            
    }
    public void ArcherTower()
    {
        int cost = TowerFactory.instance.GetTowerToBuild("ArcherTower").cost;

        if (statsPanel.CanBuy(cost))
        {
            TowerBuildManager.instance.SetTowerTobuild("ArcherTower");
            statsPanel.RemoveGold(cost);
        }
            
    }
    public void MagicTower()
    {
        int cost = TowerFactory.instance.GetTowerToBuild("MagicTower").cost;

        if (statsPanel.CanBuy(cost))
        {
            TowerBuildManager.instance.SetTowerTobuild("MagicTower");
            statsPanel.RemoveGold(cost);   
        }  
    }
}
