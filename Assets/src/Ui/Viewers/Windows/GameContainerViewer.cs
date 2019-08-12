using src.Ui.interfaces;
using src.Ui.Viewers.Windows.interfaces;
using UnityEngine;

namespace src.Ui.Viewers
{
    public class GameContainerViewer : MonoBehaviour, IWindow
    {
        public void SetEnable(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
