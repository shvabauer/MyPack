using MyPack.WindowsManager.UI.WindowControllers;
using MyPack.WindowsManager.UI.WindowControllers.Base;

using UnityEngine;

using Zenject;

namespace MyPack.WindowsManager.DI
{
    public class WindowsInstaller : MonoInstaller
    {
        [SerializeField] private FirstWindowController _firstWindowController;
        [SerializeField] private SecondWindowController _secondWindowController;
        [SerializeField] private ThirdWindowController _thirdWindowController;

        public override void InstallBindings()
        {
            Container.Bind<BaseWindow>().WithId(WindowType.FirstWindow).FromComponentOn(_firstWindowController.gameObject).AsCached();
            Container.Bind<BaseWindow>().WithId(WindowType.SecondWindow).FromComponentOn(_secondWindowController.gameObject).AsCached();
            Container.Bind<BaseWindow>().WithId(WindowType.ThirdWindow).FromComponentOn(_thirdWindowController.gameObject).AsCached();
        }
    }
}