using src.Ui.Viewers.interfaces;
using UnityEngine;

namespace src.Ui.Mvc.Windows
{
    public class GameViewer : MonoBehaviour, IWindow
    {   
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
