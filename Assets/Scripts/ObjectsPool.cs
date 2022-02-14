using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ObjectsPool : MonoBehaviour
    {
        [SerializeField] private GameObject _object;
        [SerializeField] private int AmmountToPool;
        private readonly List<GameObject> _objects = new List<GameObject>();

        private void OnEnable()
        {
            CreatePool();
        }

        private void CreatePool()
        {
            _objects.Clear();

            GameObject temp;

            for (int i = 0; i < AmmountToPool; i++)
            {
                temp = Instantiate(_object, transform);
                temp.SetActive(false);
                _objects.Add(temp);
            }
        }

        public GameObject GetObject()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (!_objects[i].activeInHierarchy)
                {
                    return _objects[i];
                }
            }
            return null;
        }

    }
}

