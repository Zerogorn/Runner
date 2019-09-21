using Assets.src.Game.Bot.Utils;
using UnityEngine;

namespace Assets.src.Game.Bot.interfaces
{
    internal interface IBotSettings
    {
        bool Trap();
        int HitBoxRadius();

        Transform Transform();
        EnumStrategy Strategy();
    }
}