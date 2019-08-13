using Assets.src.Units.Bot.interfaces;
using UnityEngine;

namespace src.Units.Bot
{
	public class BotViewer
	{
		private Transform _transform;		
		private Vector2 _startPosition;

		private IBotSettings _botSettings;
		private IState _state;

		public void Initialization(Transform botObj, Vector2 startPosition, IBotSettings botSettings)
		{
			_transform = botObj;
			_botSettings = botSettings;
			_startPosition = startPosition;
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
			_transform.localPosition = _startPosition;
 		}
		
		public void UpdatePosition(float move)
		{
			float y = _transform.localPosition.y + move;
			
			_transform.transform.localPosition = new Vector2(_transform.localPosition.x, y);
		}

		public Vector2 GetPosition()
		{
			return _transform.localPosition;
		}
	}
}
