using Assets.src.Loaders.Resources;
using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui;
using Assets.src.Ui.Factory;
using Assets.src.Ui.Models;
using Assets.src.Ui.Utils;
using src.ScrObj.Ui.interfaces;
using UnityEngine;

namespace Assets.src.App
{
    public class AppManager
    {
        private readonly ResourcesManager _resourcesManager;
        
        private UiManger _uiManger;

        public AppManager()
        {
            _resourcesManager = new ResourcesManager();
        }

        public void Initialization()
        {
            _resourcesManager.LoadResources();
            
            Lobby();
        }

        private void Lobby()
        {
            IUiPrefabs uiPrefabs = _resourcesManager.GetUiPrefabs();

            ModelContext modelContext = new ModelContext();
            WindowFactory windowFactory = new WindowFactory(uiPrefabs, modelContext);
            PopUpFactory popUpFactory = new PopUpFactory(uiPrefabs, modelContext);
            LayerFactory layerFactory = new LayerFactory(uiPrefabs, windowFactory, popUpFactory);

            Canvas canvas = uiPrefabs.Canvas();
            _uiManger = new UiManger(canvas, modelContext, layerFactory);
            _uiManger.SetActive(LayersTypes.Windows ,UiConst.WINDOW_MAIN, true);

            modelContext.MenuModel.SubscribeStart(x =>
            {
                _uiManger.SetActive(LayersTypes.Windows,
                                    UiConst.WINDOW_GAME,
                                    true);
            });

            modelContext.PopUpModel.SubscribeToMenu(x =>
            {
                _uiManger.SetActive(LayersTypes.PopUp,
                                    UiConst.POPUP_TYPE1,
                                    false);
                _uiManger.SetActive(LayersTypes.Windows,
                                    UiConst.WINDOW_MAIN,
                                    true);
            });
            modelContext.PopUpModel.SubscribeRepeat(x =>
            {
                _uiManger.SetActive(LayersTypes.PopUp,
                                    UiConst.POPUP_TYPE1,
                                    false);
                _uiManger.SetActive(LayersTypes.Windows,
                                    UiConst.WINDOW_GAME,
                                    true);
            });
        }
    }
}
