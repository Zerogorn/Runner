using Context.Mangers.interfaces;
using Game.Bot;
using Game.Bot.Strategy;
using Game.Simulation;
using Game.Validator;
using Ui.Models;

namespace Context.Mangers.Game
{
    internal sealed class ManagerGameBinder : IContextBinder
    {
        private readonly ManagerGame _managerGame;

        public ManagerGameBinder(ManagerGame managerGame)
        {
            _managerGame = managerGame;
        }

        public void Bind()
        {
            GameModel gameModel = new GameModel();
            MoveSimulation moveSimulation = new MoveSimulation();
            BotValidator botValidator = new BotValidator();
            GameFactory gameFactory = new GameFactory(gameModel, new PullMoveStrategy());

            _managerGame.Bind(gameModel, moveSimulation, botValidator, gameFactory);
        }
    }
}