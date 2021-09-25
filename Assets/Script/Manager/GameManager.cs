using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CommonReference
{
    public Bird player;
    public SpawnerPipe spanwerPipe;
    public SpawnerGround spanwerGround;
    //[SerializeField] private Spawner 
}

public class GameManager : SingletonMono<GameManager>
{
    public CommonReference commonRef;
    public GameData Data { get; private set; } = null;
    public GameStateManager State { get; private set; } = null;
    public bool IsGameOver { get; private set; } = false;

    protected override void Initialize()
    {
        base.Initialize();

        Data = new GameData();

        State = new GameStateManager(new TitleState(), new ReadyState(), new GameState());
        State.SetState(E_StateType.Title);
    }

    private void Update()
    {
        State.CurrentState?.OnUpdate();
    }

    public void OnTabScreen()
    {
        State.InvokeCurrent();
    }

    public void SetGameReady()
    {
        IsGameOver = false;
        Data.ClearScore();
    }

    public void SetGameOver()
    {
        commonRef.spanwerPipe.Stop();
        commonRef.spanwerGround.Stop();
        commonRef.player.SetEnd();

        IsGameOver = true;
    }
}
