using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    [HideInInspector] public Color originalColor;
    public Transform rangePrefab;

    public Transform projectilePrefab;

    [Header("Stats")]
    public float range;
    public float fireRate;

    [HideInInspector] public float fireCountDown = 0f;

    private void Awake()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
        UpdateRange();
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


}
