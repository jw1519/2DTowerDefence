using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    [HideInInspector] public Color originalColor;
    public Transform rangePrefab;
    public Transform projectilePrefab;

    [Header("Stats")]
    public string towerName;
    public float range;
    public float fireRate;
    public int power;
    public int cost;
    public bool isplaced = false;
    [HideInInspector] public float fireCountDown = 0f;

    [Header("upgrades")]
    public TowerUpgradePanel upgradePanel;
    public int rangeUpgradeCost;
    public int fireRateUpgradeCost;
    public int powerUpgradeCost;

    public int maxUpgradeAmount;
    [HideInInspector] public int rangeUpgradeAmount = 0;
    [HideInInspector] public int fireRateUpgradeAmount = 0;
    [HideInInspector] public int powerUpgradeAmount = 0;

    public virtual void Awake()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
        UpdateRange();
    }
    public virtual void Start()
    {
        upgradePanel = UIManager.instance.panels.Find(panel => panel.name == "TowerUpgradePanel").GetComponent<TowerUpgradePanel>();
    }
    public void UpdateRange()
    {
        rangePrefab.localScale = new Vector2(range, range);
    }
    public void HideRange()
    {
        rangePrefab.gameObject.SetActive(false);
    }
    public void ShowRange()
    {
        rangePrefab.gameObject.SetActive(true);
    }
    private void OnMouseEnter()
    {
        ShowRange();
    }
    private void OnMouseExit()
    {
        HideRange();
    }
    private void OnMouseDown()
    {
        if (upgradePanel != null)
        {
            if (upgradePanel.tower != this)
            {
                upgradePanel.SetTower(this);
                upgradePanel.OpenPanel();
                upgradePanel.UpdatePanel();
            }
            else
            {
                upgradePanel.ClosePanel();
                upgradePanel.tower = null;
            }    

        }
        else
        {
            upgradePanel = UIManager.instance.panels.Find(panel => panel.name == "TowerUpgradePanel").GetComponent<TowerUpgradePanel>();
        }
    }
    public virtual void UpgradeFireRate()
    {
        if (fireRateUpgradeAmount < maxUpgradeAmount)
        {
            fireRate *= 2;
            fireRateUpgradeAmount++;
        }
    }
    public virtual void UpgradeRange()
    {
        if (rangeUpgradeAmount < maxUpgradeAmount)
        {
            range += 2;
            UpdateRange();
            rangeUpgradeAmount++;
        }
    }
    public virtual void UpgradeDamage()
    {
        if (powerUpgradeAmount < maxUpgradeAmount)
        {
            power += 3;
            powerUpgradeAmount++;
        }
    }
}
