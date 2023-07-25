using MyPack.WindowsManager.UI.WindowControllers.Base;

using System.Collections.Generic;

using UnityEngine;

using Zenject;

namespace MyPack.WindowsManager
{
    public class WindowsManager : MonoBehaviour, IWindowsManager
    {
        private DiContainer _diContainer;

        private WindowType _currentWindowType;
        private BaseWindow _currentWindow;
        private Transform _windowsCanvas;

        private Stack<WindowType> _sequenceOfOpenedWindows = new();

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public WindowType CurrentWindowType => _currentWindowType;
        public BaseWindow CurrentWindow => _currentWindow;

        public void SetWindowsCanvas(Transform canvas)
        {
            _windowsCanvas = canvas;
        }

        public void OpenWindow(WindowType windowType)
        {
            if (CheckCanvas())
            {
                var window = InstantiateScreen(windowType);
                _currentWindowType = windowType;
                ShowWindow(window);

                _sequenceOfOpenedWindows.Push(windowType);
            }
        }

        public bool CanOpenPreviousWindow()
        {
            return _sequenceOfOpenedWindows.TryPeek(out var windowType);
        }

        public void OpenPreviousWindow()
        {
            _sequenceOfOpenedWindows.Pop();
            if (_sequenceOfOpenedWindows.TryPop(out var windowType))
            {
                OpenWindow(windowType);
            }
        }

        private BaseWindow InstantiateScreen(WindowType windowType)
        {
            var baseWindow = _diContainer.ResolveId<BaseWindow>(windowType);
            return _diContainer.InstantiatePrefabForComponent<BaseWindow>(baseWindow, _windowsCanvas);
        }

        private void ShowWindow(BaseWindow baseScreen)
        {
            if (_currentWindow != null)
                _currentWindow.Close();

            _currentWindow = baseScreen;
            _currentWindow.Initialize();
        }

        private bool CheckCanvas()
        {
            if (_windowsCanvas == null)
            {
                Debug.Log("<color=red>No Canvas. Call SetWindowsCanvas(Transform canvas) before opening window</color>");
                return false;
            }

            return true;
        }

    }
}