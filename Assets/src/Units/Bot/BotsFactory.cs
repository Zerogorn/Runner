using System.Collections.Generic;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.Units.Bot.interfaces;
using UnityEngine;

namespace src.Units.Bot
{
	public class BotsFactory
	{
		private readonly IBotsSettingsCollection _botsSettingsCollection;
		
		public BotsFactory(IBotsSettingsCollection botsSettingsCollection)
		{
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

				xCurrent += xStep;
				Vector2 startPosition = new Vector2(xCurrent, yStep);
				
				Transform botObj =  Object.Instantiate(botSettings?.Transform());

				BotViewer botViewerView = new BotViewer();
				botViewerView.Initialization(botObj ,startPosition, botSettings);
				
				bots.Add(botViewerView);
			}
			
			enumerator.Dispose();

			return bots;
		}
	}
}
