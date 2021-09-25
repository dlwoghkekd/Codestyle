using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    private Dictionary<E_StateType, (StateBase state, StateBase next)> dicState =
        new Dictionary<E_StateType, (StateBase state, StateBase next)>();

    public StateBase CurrentState { get; private set; }

    public GameStateManager(params StateBase[] states)
    {
        Reset(states);
    }

    /// <summary>
    /// 파라미터 순서대로 스테이트의 순서 진행된다 가정함, 중복키에 주의
    /// 중복키 있을경우 해당값은 패스하며 진행
    /// </summary>
    /// <param name="states"></param>
    public void Reset(params StateBase[] states)
    {
        dicState.Clear();

        if (states.Length <= 0)
            return;

        var first = states[0];

        for (int i = 0; i < states.Length; i++)
        {
            if (dicState.ContainsKey(states[i].StateType))
                continue;

            var iter = states[i];
            var next = (i + 1 >= states.Length) ? first : states[i + 1];

            dicState.Add(iter.StateType, (iter, next));
        }
    }

    public void SetState(E_StateType type)
    {
        CurrentState?.OnExit();

        if (dicState.TryGetValue(type, out var state))
        {
            CurrentState = state.state;

            CurrentState.OnEnter();
        }
        else
            CurrentState = null;
    }

    public void SetNextState()
    {
        if (CurrentState == null)
            return;

        if (dicState.TryGetValue(CurrentState.StateType, out var state))
        {
            SetState(state.next.StateType);
        }
    }

    public void InvokeCurrent()
    {
        CurrentState?.InvokeAction();
    }
}
