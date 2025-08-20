using UnityEngine;

public class HomeTile : MonoBehaviour
{
    StatsPanel statsPanel;
    private void Start()
    {
        statsPanel = UIManager.instance.panels.Find(panel =>  panel.name == "StatsPanel").gameObject.GetComponent<StatsPanel>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            statsPanel.UpdateHealthText(collision.gameObject.GetComponent<BaseEnemy>().damage);
        }
    }
}
