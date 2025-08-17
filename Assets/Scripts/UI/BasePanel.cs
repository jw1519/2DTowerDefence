using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    private void Start()
    {
        UIManager.instance.RegisterPanel(this);
    }
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
