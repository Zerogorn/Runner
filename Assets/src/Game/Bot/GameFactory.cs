using System.Collections.Generic;
using App;
using Context.Mangers.Canvas;
using Context.Mangers.Resources;
using Game.Bot.interfaces;
using Game.Bot.States;
using Game.Bot.States.interfaces;
using Game.Bot.Strategy;
using Game.Bot.Strategy.interfaces;
using Ui.Components.Windows.Game;
using Ui.Models;
using UnityEngine;

namespace Game.Bot
{
    internal sealed class GameFactory
    {
        private readonly GameModel _gameModel;
        private readonly PullMoveStrategy _pullMoveStrategy;

        private readonly float _ySpace = 1.4f;

        public GameFactory(GameModel gameModel, PullMoveStrategy pullMoveStrategy)
        {
            _gameModel = gameModel;
            _pullMoveStrategy = pullMoveStrategy;
        }

        private IManagerCanvas managerCanvas => AppManagerProvider.Get().ContextManagers.ManagerCanvas.Instance();
        private IResourcesManager resourcesManager => AppManagerProvider.Get().ContextManagers.ResourcesManager.Instance();

        public GameViewer GameContainer()
        {
            GameViewer game = resourcesManager.GamePrefabs.GameContainer(managerCanvas.CurrentСanvas.transform);

            GamePresenter presenter = new GamePresenter(game, _gameModel);

            return game;
        }

        public IList<BotViewer> GetBots(Transform parent)
        {

            IList<BotViewer> bots = new List<BotViewer>();

            IEnumerator<IBotSettings> enumerator = resourcesManager.GamePrefabs
                                                                   .GetBotsSettings()
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

            float xStep = managerCanvas.Width
                   / (resourcesManager.GamePrefabs.GetBotsSettings().Count
                    + 1);

            float x = -managerCanvas.XMax + i * xStep;
            float y = managerCanvas.YMax * _ySpace;

            return new Vector2(x, y);
        }
    }
}
