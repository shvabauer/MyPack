using MyPack.WindowsManager.UI.WindowControllers.Base;

using UnityEngine;
using UnityEngine.UI;

using Zenject;

namespace MyPack.WindowsManager.UI.WindowControllers
{
    public class FirstWindowController : BaseWindow
    {
        [SerializeField] private Button _btnPreviousWindow;
        [SerializeField] private Button _btnSecondWindow;
        [SerializeField] private Button _btnThirdWindow;

        private IWindowsManager _windowsManager;

        [Inject]
        private void Construct(IWindowsManager windowsManager)
        {
            _windowsManager = windowsManager;
        }

        public override void Initialize()
        {
            base.Initialize();

            Debug.Log($"FirstWindow opened");
        }

        public override void Close()
        {
            base.Close();

            _btnSecondWindow.onClick.RemoveAllListeners();
            _btnThirdWindow.onClick.RemoveAllListeners();
            _btnPreviousWindow.onClick.RemoveAllListeners();

            Debug.Log($"FirstWindow closed");
        }

        public override void InitButtons()
        {
            _btnSecondWindow.onClick.AddListener(() => OnClick(WindowType.SecondWindow));
            _btnThirdWindow.onClick.AddListener(() => OnClick(WindowType.ThirdWindow));

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