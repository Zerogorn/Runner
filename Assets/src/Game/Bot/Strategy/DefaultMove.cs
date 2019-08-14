using Assets.src.Units.Bot.interfaces;
using UnityEngine;

namespace Assets.src.Units.Bot.Strategy
{
	internal sealed class DefaultMove : IMoveStrategy
    {
        public void Move(Transform transform
                         , float move)
		{
			float y = transform.localPosition.y - Mathf.Abs(move);
			transform.localPosition = new Vector3(transform.localPosition.x, y);
        }
    }
}
