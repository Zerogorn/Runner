using Assets.src.Units.Bot.Utils;
using UnityEngine;

namespace Assets.src.Units.Bot.interfaces
{
    internal interface IBotSettings
    {
        bool Trap();
        int HitBoxRadius();

        Transform Transform();
        EnumStrategy Strategy();
    }
}