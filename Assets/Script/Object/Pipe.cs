using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Spawnable
{
    [SerializeField] private Transform trTop;
    [SerializeField] private Transform trBottom;

    public float GoalCenterY { get; private set; } = 0f;

    public void SetGoal(float centerY)
    {
        GoalCenterY = centerY;

        var rndHeight = Random.Range(Constant.PIPE_GOAL_HEIGHT_MIN, Constant.PIPE_GOAL_HEIGHT_MAX) * .5f;

        var posTop = trTop.localPosition;
        posTop.y = GoalCenterY + rndHeight;

        trTop.localPosition = posTop;

        var posBottom = trBottom.localPosition;
        posBottom.y = GoalCenterY - rndHeight;

        trBottom.localPosition = posBottom;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.IsGameOver)
            return;

        if (collision.CompareTag(Constant.TAG_PLAYER) == false)
            return;
            
        GameManager.Instance.Data.AddScore(1);
    }

    private void OnDrawGizmos()
    {
        var vec = this.transform.position;
        vec.y = GoalCenterY;
        Gizmos.DrawSphere(vec, .1f);
    }
}
