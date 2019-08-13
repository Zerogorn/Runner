using System.Collections.Generic;
using src.Units.Bot;
using UniRx;
using UnityEngine;

namespace Assets.src.Ui.Models
{
	public class GameModel
	{
		private readonly float _lostPosition;
		private readonly ReactiveCollection<BotViewer> _bots;

		public GameModel()
		{
			_lostPosition = -(Screen.height / 2);
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
				if(enumerator.Current != null 
				   && enumerator.Current.GetPosition().y.CompareTo(_lostPosition).Equals(-1))
					enumerator.Current.ResetPosition();
			
			enumerator.Dispose();
		}
	}
}
