using src.Loaders.Resources;
using src.ScrObj.Ui;
using src.ScrObj.Ui.interfaces;
using src.Ui;
using src.Ui.Layers;
using UnityEngine;

namespace src.App
{
    public class AppManager
    {
        private readonly ResourcesManager _resourcesManager;
        
        private LayerFactory _layerFactory;
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
            _layerFactory = new LayerFactory(uiPrefabs);

            Canvas canvas = uiPrefabs.Canvas();
            _uiManger = new UiManger(canvas, _layerFactory);
        }
    }
}
