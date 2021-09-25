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
    /// �Ķ���� ������� ������Ʈ�� ���� ����ȴ� ������, �ߺ�Ű�� ����
    /// �ߺ�Ű ������� �ش簪�� �н��ϸ� ����
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
