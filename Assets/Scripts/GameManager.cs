using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int wave;
    public int amountOfEnemiesToSpawn;
    public WaveSpawner waveSpawner;

    StatsPanel statsPanel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
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
            wave = 0;
            amountOfEnemiesToSpawn = 5;
        }
        else
        {
            Debug.Log("Path not connected");
        }
        enemy.SetActive(false);

    }

    public void NextWave()
    {
        wave++;
        if (statsPanel != null)
        {
            statsPanel.UpdateRoundText(wave);
        }
        amountOfEnemiesToSpawn *= 2;
        //spawn enemies
        StartCoroutine(waveSpawner.SpawnWave(amountOfEnemiesToSpawn));
    }

    public void GameOver(int gold)
    {
        GameOverPanel gameOverPanel = UIManager.instance.panels.Find(panel => panel.name == "GameOverPanel").gameObject.GetComponent<GameOverPanel>();
        gameOverPanel.OpenPanel();
        gameOverPanel.UpdateRoundText(wave);
        gameOverPanel.UpdateGoldText(gold);
    }
}
