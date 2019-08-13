﻿using System;
using System.Collections.Generic;
using Assets.src.Ui.Mvc.interfaces;
using src.Units.Bot;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Assets.src.Ui.Mvc.Windows.Game
{
    public class GameViewer : MonoBehaviour, IWindow
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
