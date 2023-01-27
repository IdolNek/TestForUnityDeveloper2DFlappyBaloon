using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _contenier;
    [SerializeField] private int _capacity;
    [SerializeField] private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _contenier.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }
    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
    public void ResetPool()
    {
        foreach (GameObject spawned in _pool)
        {
            spawned.SetActive(false);
        }
    }
    protected void DisableObjectAbroadScreen()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                Vector3 point = _camera.WorldToViewportPoint(item.transform.position);
                if (point.x < 0)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}
