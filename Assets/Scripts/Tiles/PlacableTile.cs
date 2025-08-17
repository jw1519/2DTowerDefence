using UnityEngine;

public class PlacableTile : BaseTile
{
    public Color hoverColor = Color.black;
    public GameObject tower; // tower on tile

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (tower == null)
        {
            TowerBuildManager.instance.PlaceTower(this);
        }
    }
    public virtual void OnMouseEnter()
    {
        if (GameStateManager.instance.currentState != GameState.GameBoardSetup)
        {
            spriteRenderer.color = hoverColor;
        }
    }
    public virtual void OnMouseExit()
    {
        if (GameStateManager.instance.currentState != GameState.GameBoardSetup)
        {
            spriteRenderer.color = startColor;
        }
    }
}
