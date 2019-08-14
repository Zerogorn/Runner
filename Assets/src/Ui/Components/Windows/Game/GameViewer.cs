using System.Collections.Generic;
using src.Ui.Components.interfaces;
using src.Units.Bot;
using UnityEngine;

namespace src.Ui.Components.Windows.Game
{
    internal sealed class GameViewer : MonoBehaviour, IWindow
    {        
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
