using TMPro;
using UnityEngine;

public class StatsPanel : BasePanel
{
    public int currentHealth;
    [Header("stats text")]
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI goldText;
    public void UpdateRoundText(int round)
    {
        roundText.text = "Round " + round;
    }
    public void UpdateHealthText(int health)
    {
        healthText.text = health.ToString();
    }
    public void SubtractFromHealth(int amount)
    {
        currentHealth -= amount;
        healthText.text  = currentHealth.ToString();
    }
    public void UpdateGoldText(int Gold)
    {
        goldText.text = Gold.ToString();    
    }
}
