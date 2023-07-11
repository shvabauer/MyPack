using MyPack.PoolingObjects.Pool;
using MyPack.PoolingObjects.Pool.Controller;

using UnityEngine;
using UnityEngine.UI;

using Zenject;

namespace MyPack.PoolingObjects
{
    public class TestPoolWindow : MonoBehaviour
    {
        [SerializeField] private Button _btn1;
        [SerializeField] private Button _btn2;
        [SerializeField] private Button _btn3;

        [SerializeField] private Circle _circle;
        [SerializeField] private Square _square;
        [SerializeField] private Triangle _triangle;

        private int index = 0;


        private IPoolController _poolController;

        [Inject]
        private void Construct(IPoolController poolController)
        {
            _poolController = poolController;
        }

        void Start()
        {
            _btn1.onClick.AddListener(() => Spawn(_circle));
            _btn2.onClick.AddListener(() => Spawn(_square));
            _btn3.onClick.AddListener(() => Spawn(_triangle));
        }

        private void Spawn(Poolable item)
        {
            var testElement = _poolController.GetItem(item);
            testElement.Init(index);
            testElement.OnReleaseItem += ReleaseItem;

            index++;
        }

        private void ReleaseItem(Poolable item)
        {
            _poolController.ReleaseItem(item);
        }
    }
}