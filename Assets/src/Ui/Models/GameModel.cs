using System;
using System.Collections.Generic;
using src.Units.Bot;
using UniRx;

namespace Assets.src.Ui.Models
{
	public class GameModel
	{
		private readonly ReactiveCollection<BotViewer> _bots;

		public GameModel()
		{
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
	}
}
