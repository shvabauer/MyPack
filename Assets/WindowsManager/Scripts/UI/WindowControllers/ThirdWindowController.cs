using MyPack.WindowsManager.UI.WindowControllers.Base;

using UnityEngine;
using UnityEngine.UI;

using Zenject;

namespace MyPack.WindowsManager.UI.WindowControllers
{
    public class ThirdWindowController : BaseWindow
    {
        [SerializeField] private Button _btnPreviousWindow;
        [SerializeField] private Button _btnFirstWindow;
        [SerializeField] private Button _btnSecondWindow;

        private IWindowsManager _windowsManager;

        [Inject]
        private void Construct(IWindowsManager windowsManager)
        {
            _windowsManager = windowsManager;
        }

        public override void Initialize()
        {
            base.Initialize();

            Debug.Log($"ThirdWindow opened");
        }

        public override void Close()
        {
            base.Close();

            _btnFirstWindow.onClick.RemoveAllListeners();
            _btnSecondWindow.onClick.RemoveAllListeners();
            _btnPreviousWindow.onClick.RemoveAllListeners();

            Debug.Log($"ThirdWindow closed");
        }

        public override void InitButtons()
        {
            _btnFirstWindow.onClick.AddListener(() => OnClick(WindowType.FirstWindow));
            _btnSecondWindow.onClick.AddListener(() => OnClick(WindowType.SecondWindow));

            if (_windowsManager.CanOpenPreviousWindow())
            {
                _btnPreviousWindow.gameObject.SetActive(true);
                _btnPreviousWindow.onClick.AddListener(OnBackClick);
            }
            else
            {
                _btnPreviousWindow.gameObject.SetActive(false);
            }
        }

        private void OnClick(WindowType windowType)
        {
            _windowsManager.OpenWindow(windowType);
        }

        private void OnBackClick()
        {
            _windowsManager.OpenPreviousWindow();
        }
    }
}