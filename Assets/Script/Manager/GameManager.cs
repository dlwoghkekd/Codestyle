using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CommonReference
{
    public Bird player;
    public SpawnerPipe spanwerPipe;
    public SpawnerGround spanwerGround;
}

public class GameManager : SingletonMono<GameManager>
{
    // 게임에 사용되는 오브젝트 레퍼런스
    public CommonReference commonRef;
    // 게임 데이터
    public GameData Data { get; private set; } = null;
    // 게임의 상태
    public GameStateManager State { get; private set; } = null;
    // 게임오버 플래그
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
