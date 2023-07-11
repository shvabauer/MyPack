namespace MyPack.PoolingObjects.Pool.Controller
{
    public interface IPoolController
    {
        public Poolable GetItem(Poolable item);
        public void ReleaseItem(Poolable item);
    }
}