using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스폰 가능 오브젝트
public class Spawnable : MonoBehaviour
{
    // 스포너
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