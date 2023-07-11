using MyPack.PoolingObjects.Pool.Controller;

using Zenject;

namespace MyPack.PoolingObjects.DI
{
    public class PoolControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PoolController>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}