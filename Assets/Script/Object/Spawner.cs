using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected Spawnable spawnTarget;
    [field: SerializeField] public List<Spawnable> ListSpawned { get; private set; }

    protected Queue<Spawnable> quePool = new Queue<Spawnable>();

    public Spawnable lastSpawnTarget { get; private set; } = null;

    public void Awake()
    {
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
