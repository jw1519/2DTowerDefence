using TMPro;
using UnityEngine;

public class TowerUpgradePanel : BasePanel
{
    BaseTower tower;
    public TextMeshProUGUI towerNameText;
    public TextMeshProUGUI rangeCostText;
    public TextMeshProUGUI fireRateCostText;
    public TextMeshProUGUI damageCostText;

    public void SetTower(BaseTower tower)
    {
        this.tower = tower;
    }
    private void OnEnable()
    {
        if (tower != null)
        {
            towerNameText.text = tower.towerName;
            rangeCostText.text = tower.rangeUpgradeCost.ToString();
            fireRateCostText.text = tower.fireRateUpgradeCost.ToString();
            damageCostText.text = tower.damageUpgradeCost.ToString();
        }
        
    }

}
