using MyPack.PoolingObjects.Pool;

using System;
using System.Collections;

using UnityEngine;

using Random = UnityEngine.Random;

namespace MyPack.PoolingObjects
{
    public abstract class Shape : Poolable
    {
        public override event Action<Poolable> OnReleaseItem;
        
        private int randomTime;

        public override void Init(int index)
        {
            randomTime = Random.Range(3, 10);
            StartCoroutine(Delay(randomTime));
        }

        private IEnumerator Delay(int seconds)
        {
            yield return new WaitForSeconds(seconds);

            OnReleaseItem?.Invoke(this);
        }
    }
}
