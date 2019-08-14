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
        
        public void AddBots(IEnumerable<BotViewer> bots)
        {
           IEnumerator<BotViewer> enumerator = bots.GetEnumerator();

            while (enumerator.MoveNext())
            {
                BotViewer botViewer = enumerator.Current;

                if (botViewer == null)
                    continue;

                botViewer.SetActive(true);
                botViewer.SetParent(transform);
                
                botViewer.ResetPosition();
            }
            
            enumerator.Dispose();
        }
    }
}
