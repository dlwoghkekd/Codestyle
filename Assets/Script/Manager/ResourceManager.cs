using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum E_ResourceType
{
    UIPanel
}

public class ResourceManager : SingletonMono<ResourceManager>
{
    public bool Get<T>(E_ResourceType type, out T resource) where T : UnityEngine.Object
    {
        var path = $"{type}/{typeof(T).ToString()}";

        resource = Resources.Load<T>(path);

        return resource != null;
    }
}