using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;

    [SerializeField] private Animator anim;

    public void SetReady()
    {
        rigid.velocity = Vector2.zero;
        
        var pos = transform.position;
        pos.y = 0;

        transform.position = pos;

        anim.SetTrigger(Constant.TRIGGER_START);
        rigid.simulated = false;

        this.gameObject.SetActive(true);
    }

    public void SetStart()
    {
        this.gameObject.SetActive(true);
        anim.SetTrigger(Constant.TRIGGER_START);
        rigid.simulated = true;
    }

    public void SetEnd()
    {
        anim.SetTrigger(Constant.TRIGGER_END);
        rigid.simulated = false;
    }

    public void Jump()
    {
        rigid.velocity = Vector2.up * Constant.FORCE_MULTIPLY;
    }
}
