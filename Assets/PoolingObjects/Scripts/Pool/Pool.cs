using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Pool;

using Object = UnityEngine.Object;

namespace MyPack.PoolingObjects.Pool
{
    public class Pool<T> : IDisposable where T : Poolable
    {
        private T _prefab;
        private Transform _container;
        private IObjectPool<T> _pool;

        public Pool(T prefab, Transform container, int prewarmObjectsAmount = 10)
        {
            _prefab = prefab;
            _container = container;
            _pool = new ObjectPool<T>(OnCreate, OnGet, OnRelease, OnDestroy, false, prewarmObjectsAmount);

            List<T> objects = new();

            for (int i = 0; i < prewarmObjectsAmount; i++)
            {
                objects.Add(_pool.Get());
            }

            foreach (var obj in objects)
            {
                _pool.Release(obj);
            }
        }

        private T OnCreate()
        {
            if (_container != null)
            {
                return Object.Instantiate(_prefab, _container);
            }
            return Object.Instantiate(_prefab);
        }

        private void OnGet(T obj)
        {
            obj?.gameObject.SetActive(true);
        }

        private void OnRelease(T obj)
        {
            obj?.gameObject.SetActive(false);
        }

        private void OnDestroy(T obj)
        {
            Object.Destroy(obj?.gameObject);
        }
        public T Get()
        {
            var obj = _pool.Get();
            return obj;
        }

        public void Release(T obj)
        {
            _pool.Release(obj);
        }

        public void Dispose()
        {
            _prefab = null;
            _container = null;
            _pool.Clear();
        }
    }
}