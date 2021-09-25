using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : StateBase
{
    public override E_StateType StateType => E_StateType.Game;

    private CommonReference commonRef;

    private float tmr = 0f;

    public override void OnEnter()
    {
        UIManager.Instance.Open<UIPanelGame>();
        commonRef = GameManager.Instance.commonRef;
        commonRef.spanwerPipe.Play();

        tmr = 0f;

        var player = commonRef.player;
        player.SetStart();
    }

    public override void OnExit()
    {
        UIManager.Instance.Close<UIPanelGame>();
        commonRef.spanwerPipe.Stop();
    }

    public override void OnUpdate()
    {
        if (commonRef.spanwerPipe.IsPlaying == false)
            return;

        tmr += Time.deltaTime;

        if (tmr >= Constant.SPAWN_TMR)
        {
            tmr = 0;
            commonRef.spanwerPipe.Spawn();
        }
    }

    public override void InvokeAction()
    {
        base.InvokeAction();

        if (GameManager.Instance.IsGameOver == false)
        {
            commonRef.player.Jump();
        }
        else
        {
            GameManager.Instance.State.SetState(E_StateType.Ready);
        }
    }
}
