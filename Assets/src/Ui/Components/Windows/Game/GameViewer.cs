using Ui.Components.interfaces;
using UnityEngine;

namespace Ui.Components.Windows.Game
{
    internal sealed class GameViewer : MonoBehaviour, IWindow
    {
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
