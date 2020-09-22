using Game.Bot.Utils;
using UnityEngine;

namespace Game.Bot.interfaces
{
    internal interface IBotSettings
    {
        bool Trap();
        int HitBoxRadius();

        Transform Transform();
        EnumStrategy Strategy();
    }
}