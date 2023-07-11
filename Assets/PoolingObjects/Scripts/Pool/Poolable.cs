using System;
using UnityEngine;

namespace MyPack.PoolingObjects.Pool
{
    public abstract class Poolable : MonoBehaviour
    {
        public abstract void Init(int index);
        public abstract event Action<Poolable> OnReleaseItem;
    }
}