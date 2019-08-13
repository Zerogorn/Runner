using Assets.src.Units.Bot.Strategy;
using Assets.src.Units.Bot.Utils;
using src.Units.Bot;
using UnityEngine;

namespace Assets.src.Units.Bot.interfaces
{
    public interface IBotSettings
    {
        bool Trap();
        int HitBoxRadius();

        Vector3 LocalScale();
        Transform Transform();
        EnumStrategy Strategy();
    } 
}