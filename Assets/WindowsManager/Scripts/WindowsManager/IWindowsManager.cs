using MyPack.WindowsManager.UI.WindowControllers.Base;

using UnityEngine;

namespace MyPack.WindowsManager
{
    public interface IWindowsManager
    {
        WindowType CurrentWindowType { get; }
        BaseWindow CurrentWindow { get; }
        void SetWindowsCanvas(Transform canvas);
        void OpenWindow(WindowType windowType);
        bool CanOpenPreviousWindow();
        void OpenPreviousWindow();
    }
}