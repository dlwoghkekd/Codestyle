using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleState : StateBase
{
    public override E_StateType StateType => E_StateType.Title;

    public override void OnEnter()
    {
        var commonRef = GameManager.Instance.commonRef;

        UIManager.Instance.Open<UIPanelTitle>();
        
        var birdObject = commonRef.player.gameObject;
        birdObject.SetActive(false);

        commonRef.spanwerGround.Play();
    }

    public override void OnExit()
    {
        UIManager.Instance.Close<UIPanelTitle>();
    }

    public override void InvokeAction()
    {
        base.InvokeAction();

        GameManager.Instance.State.SetNextState();
    }
}
