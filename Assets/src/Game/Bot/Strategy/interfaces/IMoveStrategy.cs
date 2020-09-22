using UnityEngine;

namespace Game.Bot.Strategy.interfaces
{
    internal interface IMoveStrategy
    {
        void Move(Transform transform
                  , float move);
    }
}
