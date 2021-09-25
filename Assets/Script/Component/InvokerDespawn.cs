using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokerDespawn : MonoBehaviour
{
    [SerializeField, Tag] private string targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(targetTag) == false)
            return;

        if (collision.gameObject.TryGetComponent<Spawnable>(out var target))
        {
            target.Despawn();
        }
    }

#if UNITY_EDITOR
    private Collider2D collider;

    private void OnEnable()
    {
        if (collider == false)
            collider = GetComponent<Collider2D>();
    }

    private void Reset()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnDrawGizmos()
    {
        if (collider == false)
            return;

        EditorUtil.Draw2DCollider(this.collider);
    }
#endif
}
