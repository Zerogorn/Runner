using Utils.Container;

namespace Context.Mangers.Game
{
    internal sealed class ManagerGameFactory
    {
        private readonly Container<ManagerGame, IManagerGame> _managerGameContainer;
        private readonly ManagerGame _managerGame;
        private readonly ManagerGameBinder _managerGameBinder;

        public ManagerGameFactory()
        {
            _managerGame = new ManagerGame();
            _managerGameBinder = new ManagerGameBinder(_managerGame);
            _managerGameContainer = new Container<ManagerGame, IManagerGame>();
        }

        public Container<ManagerGame, IManagerGame> Create()
        {
            _managerGameBinder.Bind();
            _managerGameContainer.Swap(_managerGame);

            return _managerGameContainer;
        }
    }
}