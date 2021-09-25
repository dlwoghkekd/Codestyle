using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGround : Spawner
{
    [SerializeField] private Transform despawnPoint;

    private int despawnCount = 0;

    private bool isPlay = false;

    public void Play() => isPlay = true;
    
    public void Stop() => isPlay = false;
    
    private void Update()
    {
        if (isPlay == false)
            return;

        despawnCount = 0;

        MoveSpawned();

        SpawnGround();
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

            if (iter.transform.position.x <= despawnPoint.position.x)
            {
                iter.Despawn();
                despawnCount++;
            }
        }
    }

    // 디스폰된 바닥이 있다면 마지막으로 붙여줌
    private void SpawnGround()
    {
        for (int i = 0; i < despawnCount; i++)
        {
            var lastPos = lastSpawnTarget?.transform.position ?? Vector3.zero;
            lastPos.x += Constant.GROUND_INTERVAL;

            var spawn = Spawn(lastPos);
        }
    }
}
