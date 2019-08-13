using Assets.src.Units.Bot.interfaces;
using src.Units.Bot.States;
using UnityEngine;

namespace src.Units.Bot
{
	public class BotViewer
	{
		private Transform _transform;		
		private Vector2 _startPosition;

		private IBotSettings _botSettings;
		private IMoveStrategy _moveStrategy;
		private IState _state;

		public void Initialization(Transform botObj, 
								   Vector2 startPosition, 
								   IBotSettings botSettings,
								   IMoveStrategy moveStrategy)
		{
			_transform = botObj;
			_botSettings = botSettings;
			_startPosition = startPosition;
			_moveStrategy = moveStrategy;
			
			_state = new Live();
		}
		
		public void SetActive(bool active)
		{
			_transform.gameObject.SetActive(active);
		}

		public void SetParent(Transform parent)
		{
			_transform.SetParent(parent);
			_transform.localScale = _botSettings.LocalScale();

			ResetPosition();
		}
		
		public void ResetPosition()
		{
			_state.Update();
			
			_transform.localPosition = _startPosition;
			
			_state.Update();
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
			return _botSettings.HitBoxRadius();
		}

		public bool GetTrap()
		{
			return _botSettings.Trap();
		}
	}
}
