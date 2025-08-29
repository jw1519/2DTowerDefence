using TMPro;
using UnityEngine;

public class StatsPanel : BasePanel
{
    public int currentHealth;
    public int currentGold = 100;
    int totalGold;
    [Header("stats text")]
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI goldText;
    private void Start()
    {
        healthText.text = currentHealth.ToString();
        currentGold = 100;
        goldText.text = currentGold.ToString();
    }
    public void UpdateRoundText(int wave)
    {
        waveText.text = "Wave " + wave;
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
    public bool CanBuy(int amount)
    {
        if (currentGold - amount >= 0)
        {
            return true;
        }
        Debug.Log("not enough gold");
        return false;
    }
}
