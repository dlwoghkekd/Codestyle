using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                T target = FindObjectOfType<T>();

                if (target == null)
                {
                    var obj = new GameObject(typeof(T).ToString());
                    target = obj.AddComponent<T>();
                }

                instance = target;
            }

            return instance;
        }
    }

    private static T instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        instance = this as T;

        Initialize();
    }

    private void OnAwake()
    {

    }

    protected virtual void Initialize() { }
}
