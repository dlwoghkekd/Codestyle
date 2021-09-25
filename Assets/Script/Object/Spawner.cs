using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ���� ��� ������Ʈ
    [SerializeField] protected Spawnable spawnTarget;

    // �����ǰ��ִ� ������Ʈ��
    [field: SerializeField] public List<Spawnable> ListSpawned { get; private set; }

    // �����Ǵ� ������Ʈ ��, ������ ������Ʈ��
    protected Queue<Spawnable> quePool = new Queue<Spawnable>();

    // ���������� ������ ������Ʈ
    public Spawnable lastSpawnTarget { get; private set; } = null;

    public void Awake()
    {
        // �ʱ�ȭ ���� �̸� ��ϵ� ������Ʈ�� �ִٸ�, �ش� ������Ʈ �ʱ�ȭ
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
