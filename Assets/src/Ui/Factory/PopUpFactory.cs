using App;
using Context.Mangers.Game;
using Context.Mangers.Resources;
using Context.Mangers.Ui;
using ScrObj.Ui.interfaces;
using Ui.Components.Popups;
using Ui.Models;
using Ui.Utils;
using UnityEngine;
using Utils.Container.interfaces;

namespace Ui.Factory
{
    internal sealed class PopUpFactory
    {
        private IContextContainer<ResourcesManager, IResourcesManager> resourcesManager => AppManagerProvider.Get().ContextManagers.ResourcesManager;
        private IContextContainer<ManagerGame, IManagerGame> managerGame => AppManagerProvider.Get().ContextManagers.ManagerGame;
        private IContextContainer<ManagerUi, IManagerUi> managerUi => AppManagerProvider.Get().ContextManagers.ManagerUi;

        public PopUpViewer PopUp(Transform parent)
        {
            IUiPrefabs uiPrefabs = resourcesManager.Instance().UiPrefabs;

            PopUpViewer popUpViewer = resourcesManager.Instance().UiPrefabs.Popup(parent);
            popUpViewer.Initialization(uiPrefabs);
            
            PopUpModel popUpModel = new PopUpModel();
            popUpModel.SubscribeToMenu(x =>
            {
                managerUi.Instance().HideOpenPopup();
                managerUi.Instance().SetActive(LayersTypes.Windows, UiConst.WINDOW_MAIN, true);
            });
            popUpModel.SubscribeRepeat(x =>
            {
                managerUi.Instance().HideOpenPopup();
                managerGame.Instance().StartGame();
            });

            PopUpPresenter presenter = new PopUpPresenter(popUpViewer, popUpModel);

            return popUpViewer;
        }
    }
}
