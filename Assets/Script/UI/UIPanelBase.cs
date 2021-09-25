using UnityEngine;

public abstract class UIPanelBase : MonoBehaviour
{
    public virtual void OnOpen() { }
    public virtual void OnClose() { }

    public void OnTabScreen()
    {
        GameManager.Instance.OnTabScreen();
    }

}
