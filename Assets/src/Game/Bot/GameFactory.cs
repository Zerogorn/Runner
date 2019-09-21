using System.Collections.Generic;
using Assets.src.App;
using Assets.src.Game.Bot.interfaces;
using Assets.src.Game.Bot.States;
using Assets.src.Game.Bot.States.interfaces;
using Assets.src.Game.Bot.Strategy;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.Ui.Components.Windows.Game;
using Assets.src.Ui.Models;
using Assets.src.Units.Bot.interfaces;
using UnityEngine;

namespace Assets.src.Game.Bot
{
    internal sealed class GameFactory
    {
        private readonly ModelContext _modelContext;
        private readonly IGamePrefabs _gamePrefabs;
        private readonly PullMoveStrategy _pullMoveStrategy;

        private readonly float _xStep;
        private readonly float _ySpace = 1.4f;

        public GameFactory(ModelContext modelContext
                           , PullMoveStrategy pullMoveStrategy
                           , IGamePrefabs gamePrefabs)
        {
            _modelContext = modelContext;
            _pullMoveStrategy = pullMoveStrategy;
            _gamePrefabs = gamePrefabs;

            _xStep = AppManager.GetCanvasUtils.Width
                     / (_gamePrefabs.GetBotsSettings()
                                 .Count
                        + 1);
        }

        public GameViewer GameContainer()
        {
            GameViewer game = _gamePrefabs.GameContainer(AppManager.GetCanvasUtils.UiCanvas.transform);
            GameModel gameModel = _modelContext.GameModel;

            GamePresenter presenter = new GamePresenter(game, gameModel);

            return game;
        }

        public IList<BotViewer> GetBots(Transform parent)
        {
            IList<BotViewer> bots = new List<BotViewer>();

            IEnumerator<IBotSettings> enumerator = _gamePrefabs.GetBotsSettings()
                                                            .GetEnumerator();

            int i = 1;

            while (enumerator.MoveNext())
            {
                IBotSettings botSettings = enumerator.Current;

                Transform botObj = Object.Instantiate(botSettings?.Transform(), parent);
                Vector2 startPosition = GetStartPosition(i);
                IMoveStrategy moveStrategy = _pullMoveStrategy.GetMoveStrategy(botSettings.Strategy());
                IState state = new Move(botSettings.Trap(), botSettings.HitBoxRadius());
                BotViewer botViewerView = new BotViewer(botObj, startPosition, state, moveStrategy);

                bots.Add(botViewerView);

                i++;
            }

            enumerator.Dispose();

            return bots;
        }

        private Vector2 GetStartPosition(int i)
        {
            float x = -AppManager.GetCanvasUtils.XMax + i * _xStep;
            float y = AppManager.GetCanvasUtils.YMax * _ySpace;

            return new Vector2(x, y);
        }
    }
}
