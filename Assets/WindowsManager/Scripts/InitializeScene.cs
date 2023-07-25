using UnityEngine;
using Zenject;

namespace MyPack.WindowsManager
{
    public class InitializeScene : MonoBehaviour
    {
        [SerializeField] private Transform _windowsCanvas;

        private IWindowsManager _windowsManager;

        [Inject]
        private void Construct(IWindowsManager windowsManager)
        {
            _windowsManager = windowsManager;
        }

        private void Awake()
        {
            _windowsManager.SetWindowsCanvas(_windowsCanvas);
            _windowsManager.OpenWindow(WindowType.FirstWindow);
        }
    }
}