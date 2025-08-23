using TMPro;
using UnityEngine;

public class StatsPanel : BasePanel
{
    public int currentHealth;
    public int currentGold;
    int totalGold;
    [Header("stats text")]
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI goldText;
    private void Start()
    {
        healthText.text = currentHealth.ToString();
        goldText.text = currentGold.ToString();
    }
    public void UpdateRoundText(int round)
    {
        roundText.text = "Round " + round;
    }
    public void AddToHealthText(int amount)
    {
        currentHealth += amount;
        healthText.text = currentHealth.ToString();
    }
    public void SubtractFromHealth(int amount)
    {
        currentHealth -= amount;
        healthText.text = currentHealth.ToString();
        if (currentHealth <= 0)
        {
            GameManager.instance.GameOver(totalGold);
        }
    }
    public void AddGold(int amount)
    {
        currentGold += amount;
        goldText.text = currentGold.ToString();
        totalGold += amount;
    }
    public void RemoveGold(int amount)
    {
        currentGold -= amount;
        goldText.text = currentGold.ToString();
    }
}
