using Assets.src.Ui.Components.interfaces;
using UnityEngine;

namespace Assets.src.Ui.Components.Windows.Game
{
    internal sealed class GameViewer : MonoBehaviour, IWindow
    {
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
