using System.Collections.Generic;

using UnityEngine;

namespace MyPack.PoolingObjects.Pool.Controller
{
    public class PoolController : MonoBehaviour, IPoolController
    {
        [SerializeField] private int _prewarmObjectsAmount = 10;

        private readonly Dictionary<string, Pool<Poolable>> _pools = new();
        private readonly Dictionary<string, Transform> _containers = new();

        [SerializeField] private Transform _poolsContainer;

        private Pool<Poolable> _pool;

        private void Awake()
        {
            if (_poolsContainer == null)
            {
                _poolsContainer = GetComponent<Transform>();
            }
        }

        public Poolable GetItem(Poolable item)
        {
            _pool = GetPool(item);
            return _pool.Get();
        }

        public void ReleaseItem(Poolable item)
        {
            _pool = GetPool(item);
            _pool.Release(item);
        }

        private Pool<Poolable> GetPool(Poolable item)
        {
            var objTypeStr = item.GetType().ToString();
            Pool<Poolable> pool;

            if (!_pools.ContainsKey(objTypeStr))
            {
                pool = CreateNewPool(item, objTypeStr);
            }
            else
            {
                pool = _pools[objTypeStr];
            }

            return pool;
        }

        private Pool<Poolable> CreateNewPool(Poolable item, string objTypeStr)
        {
            Transform container = null;
            if (!_containers.ContainsKey(objTypeStr))
            {
                container = CreateNewContainer(objTypeStr);
            }
            var pool = new Pool<Poolable>(item, container, _prewarmObjectsAmount);
            _pools.Add(objTypeStr, pool);

            return pool;
        }

        private Transform CreateNewContainer(string objTypeStr)
        {
            var go = new GameObject($"{objTypeStr}Container").GetComponent<Transform>();

            var container = Instantiate(go, _poolsContainer).GetComponent<Transform>();

            Destroy(go.gameObject);

            _containers.Add(objTypeStr, container);
            return container;
        }
    }
}