using Context.Mangers.interfaces;
using Game.Simulation.interfaces;
using Game.Validator.interfaces;

namespace Context.Mangers.Game
{
    internal interface IManagerGame : IContextManager
    {
        void StartGame();
        void StopGame();
        IMoveSimulation GetMoveSimulation();
        IBotValidator GetBotValidator();
    }
}