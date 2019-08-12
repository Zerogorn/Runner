using Assets.src.Units.Bot.Strategy;
using UnityEngine;

namespace Assets.src.Units.Bot.interfaces
{
    public interface IBot
    {
        bool Trap { get; }
        int Trigger { get; }
        GameObject BotObj { get; }
        IState State { get; }
        IStrategy Strategy { get; }
    } 
}