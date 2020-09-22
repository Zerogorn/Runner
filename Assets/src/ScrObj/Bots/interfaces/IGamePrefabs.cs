using System.Collections.Generic;
using Ui.Components.Windows.Game;
using UnityEngine;

namespace ScrObj.Bots.interfaces
{
    internal interface IGamePrefabs
    {
        GameViewer GameContainer(Transform parent);
        IList<BotSettings> GetBotsSettings();
    }
}