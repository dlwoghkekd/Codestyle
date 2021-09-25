// 유니크 키
public enum E_StateType
{
    Title,
    Ready,
    Game,
}

public abstract class StateBase
{
    public abstract E_StateType StateType { get; } 

    public abstract void OnEnter();
    public abstract void OnExit();
    public virtual void OnUpdate() { }
    public virtual void InvokeAction() { }
}
