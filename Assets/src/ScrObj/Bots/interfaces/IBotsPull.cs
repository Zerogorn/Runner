using System.Collections.Generic;

namespace Assets.src.ScrObj.Bots.interfaces
{
    public interface IBotsPull
    {
        List<BotSettings> GetBotsSettings();
    }
}