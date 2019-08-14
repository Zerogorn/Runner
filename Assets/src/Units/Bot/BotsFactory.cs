using System.Collections.Generic;
using Assets.src.App;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.Units.Bot.interfaces;
using src.Units.Bot.Strategy;
using UnityEditor;
using UnityEngine;

namespace src.Units.Bot
{
	internal sealed class BotsFactory
	{
		private readonly IBotsPull _botsPull;
		private readonly PullMoveStrategy _pullMoveStrategy;

		private readonly float _xStep; 
		private readonly float _ySpace = 1.3f;
		
		public BotsFactory(PullMoveStrategy pullMoveStrategy,
						   IBotsPull botsPull)
		{
			_pullMoveStrategy = pullMoveStrategy;
			_botsPull = botsPull;
			
			_xStep = AppManager.GetCanvasUtils.Width / (_botsPull.GetBotsSettings().Count + 1);
		}

		public IList<BotViewer> GetBots()
		{
			IList<BotViewer> bots = new List<BotViewer>();
			
			IEnumerator<IBotSettings> enumerator = _botsPull.GetBotsSettings().GetEnumerator();

			int i = 1;
			while (enumerator.MoveNext())
			{
				IBotSettings botSettings = enumerator.Current;

				Transform botObj =  Object.Instantiate(botSettings?.Transform());
				Vector2 startPosition = GetStartPosition(i);
				IMoveStrategy moveStrategy = _pullMoveStrategy.GetMoveStrategy(botSettings.Strategy());
				BotViewer botViewerView = new BotViewer(botObj ,startPosition, botSettings, moveStrategy);
				
				bots.Add(botViewerView);
				i++;
			}
			
			enumerator.Dispose();

			return bots;
		}

		private Vector2 GetStartPosition(int i)
		{			
			float x = - AppManager.GetCanvasUtils.XMax + i * _xStep;
			float y = AppManager.GetCanvasUtils.YMax * _ySpace;
			
			return new Vector2(x, y);
		}
	}
}
