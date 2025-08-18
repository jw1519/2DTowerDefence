using System.Collections.Generic;
using UnityEngine;
using NavMeshPlus.Components;
public class GameBoard : MonoBehaviour
{
    public static GameBoard instance;
    public List<BaseTile> tiles;
    public List<BaseTile> pathTiles;
    public GameObject pathTile;
    public GameObject startTile;

    public Transform tileParent;
    public NavMeshSurface surface;

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
            Debug.Log(y.ToString());
            for(int x = 0; x < width; x++)
            {
                Vector2 pos = new Vector2(x, y) * spacing;
                int index = Random.Range(0, tiles.Count);
                if (y == random)
                {
                    Debug.Log("here");
                    GameObject instance = Instantiate(startTile.gameObject, pos, Quaternion.identity);
                    instance.transform.SetParent(tileParent);
                    instance.transform.position = pos;
                    instance.name = "Start";
                    random = (int)(height + 1);
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
}
