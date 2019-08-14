using System.Collections.Generic;

namespace Assets.src.ScrObj.Bots.interfaces
{
    internal interface IBotsPull
    {
        List<BotSettings> GetBotsSettings();
    }
}