using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Spawnable
{
    // 위 파이프
    [SerializeField] private Transform trTop;
    // 아래 파이프
    [SerializeField] private Transform trBottom;

    public float GoalCenterY { get; private set; } = 0f;

    /// <summary>
    /// 넘어온 센터 위치를 기반으로, 위/아래 파이프 세팅
    /// </summary>
    /// <param name="centerY"></param>
    public void SetGoal(float centerY)
    {
        GoalCenterY = centerY;

        var rndHeight = Random.Range(Constant.PIPE_GOAL_HEIGHT_MIN, Constant.PIPE_GOAL_HEIGHT_MAX) * .5f;

        var posTop = trTop.localPosition;
        posTop.y = GoalCenterY + rndHeight;
        posTop.y = Mathf.Clamp(posTop.y, 0, Constant.OBSTACLE_POS_Y_MIN);

        trTop.localPosition = posTop;

        var posBottom = trBottom.localPosition;
        posBottom.y = GoalCenterY - rndHeight;
        posBottom.y = Mathf.Clamp(posBottom.y, -Constant.OBSTACLE_POS_Y_MIN, 0);

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
