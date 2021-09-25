using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 스폰 대상 오브젝트
    [SerializeField] protected Spawnable spawnTarget;

    // 관리되고있는 오브젝트들
    [field: SerializeField] public List<Spawnable> ListSpawned { get; private set; }

    // 관리되는 오브젝트 중, 디스폰된 오브젝트들
    protected Queue<Spawnable> quePool = new Queue<Spawnable>();

    // 마지막으로 스폰한 오브젝트
    public Spawnable lastSpawnTarget { get; private set; } = null;

    public void Awake()
    {
        // 초기화 시점 미리 등록된 오브젝트가 있다면, 해당 오브젝트 초기화
        foreach (var iter in ListSpawned)
        {
            iter.Initialize(this);
        }

        if (ListSpawned.Count > 0)
            lastSpawnTarget = ListSpawned[ListSpawned.Count - 1];
    }

    public Spawnable Spawn(Vector3 pos)
    {
        if (quePool.Count <= 0)
        {
            var spawn = Instantiate(spawnTarget, pos, Quaternion.identity);
            spawn.Initialize(this);
            ListSpawned.Add(spawn);

            lastSpawnTarget = spawn;
            return spawn;
        }

        lastSpawnTarget = quePool.Dequeue();
        lastSpawnTarget.transform.position = pos;
        lastSpawnTarget.gameObject.SetActive(true);

        return lastSpawnTarget;
    }

    public void Despawn(Spawnable target)
    {
        target.gameObject.SetActive(false);

        quePool.Enqueue(target);
    }
}
