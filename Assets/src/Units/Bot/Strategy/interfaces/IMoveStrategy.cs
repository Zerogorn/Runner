using UnityEngine;

namespace Assets.src.Units.Bot.interfaces
{
    public interface IMoveStrategy
    {
        void Move(Transform transform, float move);
    }
}
