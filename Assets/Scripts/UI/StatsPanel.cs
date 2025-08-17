using TMPro;

public class StatsPanel : BasePanel
{
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
    public void UpdateGoldText(int Gold)
    {
        goldText.text = Gold.ToString();    
    }
}
