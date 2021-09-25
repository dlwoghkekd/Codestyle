
using UnityEngine;

class EditorUtil
{
#if UNITY_EDITOR
    public static void Draw2DCollider(Collider2D collider)
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
    }
#endif
}
