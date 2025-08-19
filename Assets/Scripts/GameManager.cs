using UnityEngine;

public class GameManager : MonoBehaviour
{
    int round;
    public int amountOfEnemiesToSpawn;
    public WaveSpawner waveSpawner;

    public void NewGame()
    {
        GameStateManager.instance.ChangeState(GameState.RoundSetup);
        GameBoard.instance.SetPathTiles();
        UIManager.instance.panels.Find(panel => panel.name == "TowerPanel").OpenPanel();
        round = 0;
        amountOfEnemiesToSpawn = 5;
    }
    private void Update()
    {

    }

    public void NextRound()
    {
        round++;
        amountOfEnemiesToSpawn *= 2;
        //spawn enemies
        StartCoroutine(waveSpawner.SpawnWave(amountOfEnemiesToSpawn));
    }
}
