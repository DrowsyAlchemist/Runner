using System.Collections;
using UnityEngine;

public class ObjectSpawner : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform[] _enemySpawners;
    [SerializeField] private float _spawnDelay = 1.1f;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _spawnDelay)
        {
            if (base.TryGetObject(out GameObject obj))
            {
                _elapsedTime = 0;
                SpawnEnemy(obj);
            }
        }
    }

    private void SpawnEnemy(GameObject obj)
    {
        int spawnerIndex = Random.Range(0, _enemySpawners.Length);
        Vector2 newPosition = _enemySpawners[spawnerIndex].position;
        obj.transform.position = newPosition;
    }
}
