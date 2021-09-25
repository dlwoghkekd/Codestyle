using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : Spawner
{
    [SerializeField] private Transform spawnPoint;

    public bool IsPlaying { get; private set; } = false;

    public void Play() => IsPlaying = true;

    public void Stop() => IsPlaying = false;

    public void Spawn()
    {
        var privCenter = 0f;

        if (lastSpawnTarget is Pipe pipe)
        {
            privCenter = pipe.GoalCenterY;
        }

        var spawn = Spawn(spawnPoint.position) as Pipe;

        if (spawn != null)
        {
            var center = Random.Range(privCenter - Constant.PIPE_CENTER_INTERVAL, privCenter + Constant.PIPE_CENTER_INTERVAL);
            center = Mathf.Clamp(center, -Constant.OBSTACLE_POS_Y_MIN, Constant.OBSTACLE_POS_Y_MIN);

            spawn.SetGoal(center);
        }
    }

    public void Clear()
    {
        foreach (var iter in ListSpawned)
        {
            if (iter.isActiveAndEnabled == false)
                continue;

            iter.Despawn();
        }
    }

    private void Update()
    {
        if (IsPlaying == false)
            return;

        MoveSpawned();
    }

    private void MoveSpawned()
    {
        foreach (var iter in ListSpawned)
        {
            if (iter.isActiveAndEnabled == false)
                continue;

            var pos = iter.transform.position;
            pos.x -= Time.deltaTime * Constant.OBJECT_MOVE_SPEED;
            iter.transform.position = pos;
        }
    }
}
