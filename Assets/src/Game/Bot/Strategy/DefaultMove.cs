using Game.Bot.Strategy.interfaces;
using UnityEngine;

namespace Game.Bot.Strategy
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
