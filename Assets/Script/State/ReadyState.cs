public class ReadyState : StateBase
{
    public override E_StateType StateType => E_StateType.Ready;

    public override void OnEnter()
    {
        UIManager.Instance.Open<UIPanelReady>();
        GameManager.Instance.SetGameReady();

        var commonRef = GameManager.Instance.commonRef;

        commonRef.player.SetReady();
        commonRef.spanwerGround.Play();
        commonRef.spanwerPipe.Clear();
    }

    public override void OnExit()
    {
        UIManager.Instance.Close<UIPanelReady>();
    }

    public override void InvokeAction()
    {
        base.InvokeAction();

        GameManager.Instance.State.SetNextState();
    }
}