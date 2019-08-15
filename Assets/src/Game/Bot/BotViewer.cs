using Assets.src.Units.Bot.interfaces;
using src.Units.Bot.States;
using UnityEngine;

namespace src.Units.Bot
{
	internal sealed class BotViewer
	{
		private readonly Transform _transform;
		private readonly Vector2 _startPosition;
		private readonly IMoveStrategy _moveStrategy;

		private IState _state;

		public BotViewer(Transform botObj
						 , Vector2 startPosition
						 , IState state
						 , IMoveStrategy moveStrategy)
		{
			_transform = botObj;
			_startPosition = startPosition;
			_moveStrategy = moveStrategy;

			_state = state;
		}

		public void UpdateState()
		{
			_state = _state.Update();

			_transform.localPosition = _startPosition;

			_state = _state.Update();
		}

		public void UpdatePosition(float move)
		{
			_moveStrategy.Move(_transform, move);
		}

		public Vector2 GetPosition()
		{
			return _transform.localPosition;
		}

		public float GetHitBox()
		{
			return _state.HitBoxRadius;
		}

		public bool GetTrap()
		{
			return _state.Trap;
		}
	}
}
