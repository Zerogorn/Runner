using System.Collections.Generic;
using App;
using Context.Mangers.Ui;
using Game.Bot;
using Game.Simulation;
using Game.Simulation.interfaces;
using Game.Validator;
using Game.Validator.interfaces;
using Ui.Components.Windows.Game;
using Ui.Models;
using Ui.Utils;

namespace Context.Mangers.Game
{
    internal sealed class ManagerGame : IManagerGame
    {
        private GameModel _gameModel;
        private MoveSimulation _moveSimulation;
        private BotValidator _botValidator;
        private GameFactory _gameFactory;

        private GameViewer _gameViewer;

        private IManagerUi managerUi => AppManagerProvider.Get().ContextManagers.ManagerUi.Instance();

        public void Bind(GameModel gameModel,
                         MoveSimulation moveSimulation,
                         BotValidator botValidator,
                         GameFactory gameFactory)
        {
            _gameModel = gameModel;
            _moveSimulation = moveSimulation;
            _botValidator = botValidator;
            _gameFactory = gameFactory;
        }

        public void Initialization()
        {
            CreateContainer();
            CreateBots();
            BindBots();
        }

        public void StartGame()
        {
            _moveSimulation.Start();
            _botValidator.Start();
        }

        public void StopGame()
        {
            _moveSimulation.Stop();
            _botValidator.Stop();
        }

        public IMoveSimulation GetMoveSimulation()
        {
            return _moveSimulation;
        }

        public IBotValidator GetBotValidator()
        {
            return _botValidator;
        }

        private void CreateContainer()
        {
            _gameViewer = _gameFactory.GameContainer();
        }

        private void CreateBots()
        {
            IList<BotViewer> bots = _gameFactory.GetBots(_gameViewer.transform);
            _gameModel.AddBots(bots);
            _gameModel.ResetBotsPosition();
        }

        private void BindBots()
        {
            GetMoveSimulation().SubscribeUpdate(_gameModel.UpdateBotPositions);
            GetBotValidator().Subscribe(_gameModel.ResetBotsUnderCanvas);

            _gameModel.AddLoseCounterListener(() =>
            {
                StopGame();
                
                managerUi.SetActive(LayersTypes.PopUp, UiConst.POPUP_TYPE1, true);
            });
        }
    }
}