using src.Loaders.Resources;
using src.ScrObj.Ui;
using src.ScrObj.Ui.interfaces;
using src.Ui;
using src.Ui.Factory;
using src.Ui.Layers;
using src.Ui.Models;
using src.Ui.Utils;
using UnityEngine;

namespace src.App
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
        }
    }
}
