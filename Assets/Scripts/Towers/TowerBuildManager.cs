using UnityEngine;

public class TowerBuildManager : MonoBehaviour
{
    public static TowerBuildManager instance;
    public GameObject towerToBuild;
    public Camera cam;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Update()
    {
        if (towerToBuild != null) //tower follows mouse position
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -2f; // keep it infront of tiles
            towerToBuild.transform.position = mousePos;
        }
    }
    public void SetTowerTobuild(string towerName)
    {
        GameObject instance = TowerFactory.instance.CreateTower(towerName);
        towerToBuild = instance;
    }
    public void PlaceTower(PlacableTile tile)
    {
        if (towerToBuild == null) return;
        tile.tower = towerToBuild;
        towerToBuild.transform.SetParent(tile.transform, false);

        BaseTower tower = towerToBuild.GetComponent<BaseTower>();
        tower.towerImage.GetComponent<SpriteRenderer>().color = tower.originalColor;
        towerToBuild.transform.localPosition = new Vector3(0, 0, -2);
        towerToBuild.GetComponent<Collider2D>().enabled = true;
        tower.isplaced = true;
        towerToBuild = null;
    }
}
