using UnityEngine;

public class GameManager : MonoBehaviour
{
    int round;

    public void NewGame()
    {
        GameStateManager.instance.ChangeState(GameState.RoundSetup);
        GameBoard.instance.SetPathTiles();
        UIManager.instance.panels.Find(panel => panel.name == "GameUI").OpenPanel();
        round = 0;
    }
    private void Update()
    {

    }

    public void NextRound()
    {
        round++;
        //spawn enemies with intervals
    }
}
