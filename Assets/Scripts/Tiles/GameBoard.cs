using System.Collections.Generic;
using UnityEngine;
using NavMeshPlus.Components;
using UnityEngine.AI;
public class GameBoard : MonoBehaviour
{
    public static GameBoard instance;

    public Transform tileParent;
    public NavMeshSurface surface;

    [Header("tiles")]
    public List<BaseTile> tiles;
    public List<BaseTile> pathTiles;
    public GameObject pathTile;
    public GameObject startTile;
    public GameObject endTile;

    [Header("BoardSize")]
    public float width = 5;
    public float height = 5;
    public float spacing = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        CreateNewBoard();
    }
    public void CreateNewBoard()
    {
        int random = (int)Random.Range(1, height);
        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                Vector2 pos = new Vector2(x, y) * spacing;
                int index = Random.Range(0, tiles.Count);
                if (y == random)
                {
                    GameObject instance = Instantiate(startTile.gameObject, pos, Quaternion.identity);
                    instance.transform.SetParent(tileParent);
                    instance.transform.position = pos;
                    instance.name = "Start";
                    random = (int)(height + 1);
                    FindFirstObjectByType<WaveSpawner>().spawnPoint = instance.transform;
                    startTile = instance;
                }
                else
                {
                    GameObject instance = Instantiate(tiles[index].gameObject, pos, Quaternion.identity);
                    instance.transform.SetParent(tileParent);
                    instance.transform.position = pos;
                }

            }
        }
    }
    public void AddPath(BaseTile tile)
    {
        pathTiles.Add(tile);
    }
    public void RemovePath(BaseTile tile)
    {
        pathTiles.Remove(tile);
    }
    public void SetPathTiles()
    {
        //replace tiles with path tiles
        foreach (BaseTile tile in pathTiles)
        {
            GameObject instance = Instantiate(pathTile);
            instance.transform.SetParent(tileParent);
            instance.transform.position = tile.transform.position;
            Destroy(tile.gameObject);
        }
        surface.BuildNavMeshAsync();
    }
    public bool CheckNavMesh(NavMeshAgent agent)
    {

        agent.gameObject.transform.position = startTile.transform.position;
        agent.gameObject.GetComponent<BaseEnemy>().endLocation = endTile.transform;

        foreach (BaseTile tile in pathTiles)
        {
            if (tile.gameObject.GetComponent<NavMeshModifier>() == null)
                tile.gameObject.AddComponent<NavMeshModifier>();
        }
        surface.BuildNavMesh();

        NavMeshPath path = new();
        if (agent.CalculatePath(endTile.transform.position, path))
        {
            Debug.Log("in here");
            //return true if path is complete
            return path.status == NavMeshPathStatus.PathComplete;
        }
        return false;
    }
}
