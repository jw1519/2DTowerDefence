using TMPro;
using UnityEngine;

public class TowerUpgradePanel : BasePanel
{
    BaseTower tower;
    StatsPanel statsPanel;
    public TextMeshProUGUI towerNameText;
    public TextMeshProUGUI rangeCostText;
    public TextMeshProUGUI fireRateCostText;
    public TextMeshProUGUI damageCostText;
    private void Start()
    {
        statsPanel = UIManager.instance.panels.Find(panel =>  panel.name == "StatsPanel").GetComponent<StatsPanel>();
    }
    public void SetTower(BaseTower tower)
    {
        this.tower = tower;
    }
    private void OnEnable()
    {
        UpdatePanel();
    }
    public void UpdatePanel()
    {
        if (tower != null)
        {
            towerNameText.text = tower.towerName;
            rangeCostText.text = tower.rangeUpgradeCost.ToString();
            fireRateCostText.text = tower.fireRateUpgradeCost.ToString();
            damageCostText.text = tower.damageUpgradeCost.ToString();
        }
    }
    public void UpgradeRange()
    {
        if (statsPanel != null)
        {
            if (statsPanel.CanBuy(tower.rangeUpgradeCost))
            {
                tower.UpgradeRange();
            }
        }
        else
        {
            statsPanel = UIManager.instance.panels.Find(panel => panel.name == "StatsPanel").GetComponent<StatsPanel>();
            UpgradeRange();
        }
    }
    public void UpgradeFireRate()
    {
        if (statsPanel != null)
        {
            if (statsPanel.CanBuy(tower.fireRateUpgradeCost))
            {
                tower.UpgradeFireRate();
            }
        }
        else
        {
            statsPanel = UIManager.instance.panels.Find(panel => panel.name == "StatsPanel").GetComponent<StatsPanel>();
            UpgradeFireRate();
        }
    }
    public void UpgradeDamage()
    {
        if (statsPanel != null)
        {
            if (statsPanel.CanBuy(tower.damageUpgradeCost))
            {
                tower.UpgradeDamage();
            }
        }
        else
        {
            statsPanel = UIManager.instance.panels.Find(panel => panel.name == "StatsPanel").GetComponent<StatsPanel>();
            UpgradeDamage();
        }
    }

}
