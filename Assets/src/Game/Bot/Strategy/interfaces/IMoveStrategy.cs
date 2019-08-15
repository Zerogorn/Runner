using UnityEngine;

namespace Assets.src.Units.Bot.interfaces
{
    internal interface IMoveStrategy
    {
        void Move(Transform transform
                  , float move);
    }
}
