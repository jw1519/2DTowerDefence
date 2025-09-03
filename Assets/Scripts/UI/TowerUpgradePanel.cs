using TMPro;
using UnityEngine;

public class TowerUpgradePanel : BasePanel
{
    [HideInInspector] public BaseTower tower;
    StatsPanel statsPanel;
    public TextMeshProUGUI towerNameText;
    public TextMeshProUGUI rangeCostText;
    public TextMeshProUGUI fireRateCostText;
    public TextMeshProUGUI powerCostText;
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
            int max = tower.maxUpgradeAmount;
            towerNameText.text = tower.towerName;
            if (tower.rangeUpgradeAmount < max)
            {
                rangeCostText.text = tower.rangeUpgradeCost.ToString();
            }
            else
            {
                rangeCostText.text = "Fully Upgraded";
            }
            if (tower.fireRateUpgradeAmount < max)
            {
                fireRateCostText.text = tower.fireRateUpgradeCost.ToString();
            }
            else
            {
                fireRateCostText.text = "Fully Upgraded";
            }
            if (tower.powerUpgradeAmount < max)
            {
                powerCostText.text = tower.powerUpgradeCost.ToString();
            }
            else
            {
                powerCostText.text = "Fully Upgraded";
            }
        }
    }
    public void UpgradeRange()
    {
        if (statsPanel != null)
        {
            if (statsPanel.CanBuy(tower.rangeUpgradeCost))
            {
                statsPanel.RemoveGold(tower.rangeUpgradeCost);
                tower.UpgradeRange();
            }
        }
        else
        {
            statsPanel = UIManager.instance.panels.Find(panel => panel.name == "StatsPanel").GetComponent<StatsPanel>();
            UpgradeRange();
        }
        UpdatePanel();
    }
    public void UpgradeFireRate()
    {
        if (statsPanel != null)
        {
            if (statsPanel.CanBuy(tower.fireRateUpgradeCost))
            {
                statsPanel.RemoveGold(tower.fireRateUpgradeCost);
                tower.UpgradeFireRate();
            }
        }
        UpdatePanel();
    }
    public void UpgradeDamage()
    {
        if (statsPanel != null)
        {
            if (statsPanel.CanBuy(tower.powerUpgradeCost))
            {
                statsPanel.RemoveGold(tower.powerUpgradeCost);
                tower.UpgradePower();
            }
        }
        UpdatePanel();
    }
}
