using MyPack.WindowsManager;

using Zenject;

namespace MyPack.WindowsManager.DI
{
    public class WindowManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<WindowsManager>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}