using App;
using Context.Mangers.Game;
using Context.Mangers.Resources;
using Context.Mangers.Ui;
using ScrObj.Ui.interfaces;
using Ui.Components.Windows.Menu;
using Ui.Models;
using UnityEngine;
using Utils.Container.interfaces;

namespace Ui.Factory
{
    internal sealed class WindowFactory
    {
        private IContextContainer<ResourcesManager, IResourcesManager> resourcesManager => AppManagerProvider.Get().ContextManagers.ResourcesManager;
        private IContextContainer<ManagerGame, IManagerGame> managerGame => AppManagerProvider.Get().ContextManagers.ManagerGame;
        private IContextContainer<ManagerUi, IManagerUi> managerUi => AppManagerProvider.Get().ContextManagers.ManagerUi;

        public MenuViewer Menu(Transform parent)
        {
            IUiPrefabs uiPrefabs = resourcesManager.Instance().UiPrefabs;
            MenuViewer menuViewer = uiPrefabs.Menu(parent);
            menuViewer.Initialization(uiPrefabs);

            MenuModel menuModel = new MenuModel();
            menuModel.SubscribeStart(x =>
            {
                managerUi.Instance().HideOpenWindows();
                managerGame.Instance().StartGame();
            });

            MenuPresenter presenter = new MenuPresenter(menuViewer, menuModel);

            return menuViewer;
        }
    }
}
