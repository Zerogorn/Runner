using System.Collections.Generic;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.Units.Bot.interfaces;
using src.Units.Bot.Strategy;
using UnityEngine;

namespace src.Units.Bot
{
	public class BotsFactory
	{
		private readonly IBotsSettingsCollection _botsSettingsCollection;
		private readonly PullMoveStrategy _pullMoveStrategy;
		
		public BotsFactory(PullMoveStrategy pullMoveStrategy,
						   IBotsSettingsCollection botsSettingsCollection)
		{
			_pullMoveStrategy = pullMoveStrategy;
			_botsSettingsCollection = botsSettingsCollection;
		}

		public IList<BotViewer> GetBots()
		{
			int xCurrent = - (Screen.width / 2);
			int xStep = Screen.width  / (_botsSettingsCollection.GetBotsSettings().Count + 1);
			int yStep = Screen.height / 2;
			
			IList<BotViewer> bots = new List<BotViewer>();
			
			IEnumerator<IBotSettings> enumerator = _botsSettingsCollection.GetBotsSettings().GetEnumerator();

			while (enumerator.MoveNext())
			{
				IBotSettings botSettings = enumerator.Current;

				Transform botObj =  Object.Instantiate(botSettings?.Transform());
				
				xCurrent += xStep;
				Vector2 startPosition = new Vector2(xCurrent, yStep);

				BotViewer botViewerView = new BotViewer();

				IMoveStrategy moveStrategy = _pullMoveStrategy.GetMoveStrategy(botSettings.Strategy());
				botViewerView.Initialization(botObj ,startPosition, botSettings, moveStrategy);
				
				bots.Add(botViewerView);
			}
			
			enumerator.Dispose();

			return bots;
		}
	}
}
