using TMPro;
using UnityEngine;

public class GameOverPanel : BasePanel
{
    public TextMeshProUGUI totalGoldText;
    public TextMeshProUGUI roundText;
    public void UpdateGoldText(int gold)
    {
        if (totalGoldText != null)
        {
            totalGoldText.text = "Gold Earned - " + gold;
        }
    }
    public void UpdateRoundText(int round)
    {
        if (roundText != null)
        {
            roundText.text = "Round - " + round;
        }
    }
    public void Menu()
    {

    }
}
