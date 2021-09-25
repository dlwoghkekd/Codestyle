using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMono<UIManager>
{
    private Dictionary<Type, UIPanelBase> dicPanel = new Dictionary<Type, UIPanelBase>();

    protected override void Initialize()
    {
        base.Initialize();

        dicPanel.Clear();
    }

    public UIPanelBase Open<T>() where T : UIPanelBase
    {
        UIPanelBase panel = null;

        if (dicPanel.TryGetValue(typeof(T), out panel))
        {
            panel.gameObject.SetActive(true);
            panel.OnOpen();
            return panel;
        }

        if (ResourceManager.Instance.Get<T>(E_ResourceType.UIPanel, out var resource))
        {
            panel = Instantiate(resource, this.transform);
            
            dicPanel.Add(typeof(T), panel);
            
            panel.gameObject.SetActive(true);
            panel.OnOpen();
            return panel;
        }

        return null;
    }

    public bool Open<T>(out T panel) where T : UIPanelBase
    {
        panel = Open<T>() as T;

        return panel != null;
    }

    public void Close<T>() where T : UIPanelBase
    {
        if (dicPanel.TryGetValue(typeof(T), out var panel))
        {
            panel.OnClose();
            panel.gameObject.SetActive(false);
        }
    }
}