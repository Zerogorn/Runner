using Assets.src.Managers.Ui.interfaces;
using UnityEngine;

namespace Assets.src.Viewers
{
    public class GameContainerViewer : MonoBehaviour, IWindow
    {
        public void SetEnable(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
