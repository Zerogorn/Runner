using Assets.src.Ui.Mvc.interfaces;
using UnityEngine;

namespace Assets.src.Ui.Mvc.Windows.Game
{
    public class GameViewer : MonoBehaviour, IWindow
    {   
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
