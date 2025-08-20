using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    int round;
    public int amountOfEnemiesToSpawn;
    public WaveSpawner waveSpawner;

    StatsPanel statsPanel;

    private void Start()
    {
        statsPanel = UIManager.instance.panels.Find(panel => panel.name == "StatsPanel").gameObject.GetComponent<StatsPanel>();
    }
    public void NewGame()
    {
        GameObject enemy = EnemyPool.instance.GetPooledObjectEnemy("Enemy");
        enemy.SetActive(true);
        NavMeshAgent mesh = enemy.GetComponent<NavMeshAgent>();
        if (GameBoard.instance.CheckNavMesh(mesh))
        {
            GameBoard.instance.SetPathTiles();
            GameStateManager.instance.ChangeState(GameState.RoundSetup);
            UIManager.instance.panels.Find(panel => panel.name == "TowerPanel").OpenPanel();
            round = 0;
            amountOfEnemiesToSpawn = 5;
        }
        else
        {
            Debug.Log("Path not connected");
        }
        enemy.SetActive(false);

    }

    public void NextRound()
    {
        round++;
        if (statsPanel != null)
        {
            statsPanel.UpdateRoundText(round);
        }
        amountOfEnemiesToSpawn *= 2;
        //spawn enemies
        StartCoroutine(waveSpawner.SpawnWave(amountOfEnemiesToSpawn));
    }
}
