using UnityEngine;

public class BaseTile : MonoBehaviour
{
    public Sprite tileSprite;
    [HideInInspector] public Color startColor;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    public virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tileSprite;
        SetColor();
    }
    public virtual void OnMouseDown()
    {
        if (GameStateManager.instance.currentState == GameState.GameBoardSetup)
        {
            if (spriteRenderer.color == startColor)
            {
                spriteRenderer.color = Color.yellow;
                GameBoard.instance.AddPath(this);
            }
            else
            {
                spriteRenderer.color = startColor;
                GameBoard.instance.RemovePath(this);
            }
            
        }
    }
    public void SetColor()
    {
        startColor = spriteRenderer.color;
    }
}
