using System.Collections.Generic;
using Assets.src.Game.Bot;
using Assets.src.Game.Simulation;
using Assets.src.Game.Validator;
using Assets.src.Ui.Components.Windows.Game;
using Assets.src.Ui.Models;
using src.Game.Simulation.interfaces;
using src.Game.Validator.interfaces;

namespace Assets.src.Game
{
    internal sealed class GameManager
    {
        private readonly ModelContext _modelContext;
        private readonly MoveSimulation _moveSimulation;
        private readonly BotValidator _botValidator;
        private readonly GameFactory _gameFactory;

        private GameViewer _gameViewer;

        public GameManager(ModelContext modelContext
                           , MoveSimulation moveSimulation
                           , BotValidator botValidator
                           , GameFactory gameFactory)
        {
            _modelContext = modelContext;
            _moveSimulation = moveSimulation;
            _botValidator = botValidator;
            _gameFactory = gameFactory;

            CreateContainer();
            CreateBots();
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
            _modelContext.GameModel.AddBots(bots);
            _modelContext.GameModel.ResetBotsPosition();
        }
    }
}