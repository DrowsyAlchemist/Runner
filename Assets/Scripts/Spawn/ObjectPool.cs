using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        if (result != null)
        {
            result.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }
}
