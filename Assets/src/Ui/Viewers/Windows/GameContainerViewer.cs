using src.Ui.Viewers.Windows.interfaces;
using UnityEngine;

namespace src.Ui.Viewers.Windows
{
    public class GameContainerViewer : MonoBehaviour, IWindow
    {   
        public void SetEnable(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
