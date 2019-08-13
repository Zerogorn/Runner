using System.Collections.Generic;
using src.Units.Bot;
using UniRx;
using UnityEngine;

namespace Assets.src.Ui.Models
{
	public class GameModel
	{
		private readonly float _yMax;
		private readonly float _xMax;
		
		private readonly ReactiveCollection<BotViewer> _bots;

		public GameModel()
		{
			_yMax = Screen.height / 2f;
			_xMax = Screen.width / 2f;
			
			_bots = new ReactiveCollection<BotViewer>();
		}
		
		public void AddBots(IEnumerable<BotViewer> bots)
		{
			IEnumerator<BotViewer> enumerator = bots.GetEnumerator();

			while (enumerator.MoveNext())
				_bots.Add(enumerator.Current);
			
			enumerator.Dispose();
		}

		public IReactiveCollection<BotViewer> GetBots()
		{
			return _bots;
		}

		public void UpdatePositions(float move)
		{
			IEnumerator<BotViewer> enumerator = _bots.GetEnumerator();

			while (enumerator.MoveNext())
				enumerator.Current?.UpdatePosition(move);
			
			enumerator.Dispose();
		}

		public void ResetBots(Unit unit)
		{
			IEnumerator<BotViewer> enumerator = _bots.GetEnumerator();

			while (enumerator.MoveNext())
			{
				if(enumerator.Current == null)
					continue;

				bool overMoveY = enumerator.Current.GetPosition().y
										.CompareTo(-_yMax)
										.Equals(-1);
				
				bool overMoveX = Mathf.Abs(enumerator.Current.GetPosition().x)
										.CompareTo(_xMax)
										.Equals(1);
				
				if (overMoveY || overMoveX)
					enumerator.Current.ResetPosition();
			}
			
			enumerator.Dispose();
		}
	}
}
