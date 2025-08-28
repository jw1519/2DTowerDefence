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
    public int damage;
    public int cost;
    public bool isplaced = false;
    [HideInInspector] public float fireCountDown = 0f;

    [Header("upgrades")]
    public TowerUpgradePanel upgradePanel;
    public int rangeUpgradeCost;
    public int fireRateUpgradeCost;
    public int damageUpgradeCost;

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
            upgradePanel.SetTower(this);
            upgradePanel.OpenPanel();
            upgradePanel.UpdatePanel();
        }
        else
        {
            upgradePanel = UIManager.instance.panels.Find(panel => panel.name == "TowerUpgradePanel").GetComponent<TowerUpgradePanel>();
        }
    }
    public void UpgradeFireRate()
    {
        fireRate *= 2;
    }
    public void UpgradeRange()
    {
        range += 2;
        UpdateRange();
    }
    public void UpgradeDamage()
    {
        damage += 3;
    }
}
