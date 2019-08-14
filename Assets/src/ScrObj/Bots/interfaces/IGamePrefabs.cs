using System.Collections.Generic;
using src.Ui.Components.Windows.Game;
using UnityEngine;

namespace Assets.src.ScrObj.Bots.interfaces
{
    internal interface IGamePrefabs
    {
        GameViewer GameContainer(Transform parent);
        IList<BotSettings> GetBotsSettings();
    }
}