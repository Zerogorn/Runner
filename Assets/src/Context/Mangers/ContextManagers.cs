using System.Collections.Generic;
using Context.Mangers.Canvas;
using Context.Mangers.Game;
using Context.Mangers.Ui;
using Context.Mangers.interfaces;
using Context.Mangers.Resources;
using Utils.Container.interfaces;

namespace Context.Mangers
{
    internal sealed class ContextManagers
    {
        private readonly IList<IContextManager> _managers;

        public IContextContainer<ManagerCanvas, IManagerCanvas> ManagerCanvas { get; private set; }
        public IContextContainer<ManagerGame, IManagerGame> ManagerGame { get; private set; }
        public IContextContainer<ResourcesManager, IResourcesManager> ResourcesManager { get; private set; }
        public IContextContainer<ManagerUi, IManagerUi> ManagerUi { get; private set; }
        
        public ContextManagers()
        {
            _managers = new List<IContextManager>();
        }

        public void Initialization()
        {
            CreateManagers();
            InitializationManagers();
        }

        private void CreateManagers()
        {
            var resourcesManagerFactory = new ResourcesManagerFactory();
            ResourcesManager = resourcesManagerFactory.Create();
            _managers.Add(ResourcesManager.Instance());

            var managerCanvasFactory = new ManagerCanvasFactory();
            ManagerCanvas = managerCanvasFactory.Create();
            _managers.Add(ManagerCanvas.Instance());

            var managerUi = new ManagerUiFactory();
            ManagerUi = managerUi.Create();
            _managers.Add(ManagerUi.Instance());

            var managerGameFactory = new ManagerGameFactory();
            ManagerGame = managerGameFactory.Create();
            _managers.Add(ManagerGame.Instance());
        }

        private void InitializationManagers()
        {
            for (int i = 0; i < _managers.Count; i++)
            {
                _managers[i].Initialization();
            }
        }
    }
}