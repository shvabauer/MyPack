using UnityEngine;

namespace MyPack.WindowsManager.UI.WindowControllers.Base
{
    public class BaseWindow : MonoBehaviour
    {
        public virtual void Initialize()
        {
            transform.SetAsFirstSibling();
            InitButtons();
        }

        public virtual void Close()
        {
            Destroy(gameObject);
        }

        public virtual void InitButtons()
        {

        }
    }
}