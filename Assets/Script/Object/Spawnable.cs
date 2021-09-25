using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    private Spawner owner = null;

    public void Initialize(Spawner _owner)
    {
        owner = _owner;
    }
    
    public virtual void Despawn()
    {
        if (owner == null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        owner.Despawn(this);
    }
}