using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui.Layers;
using Assets.src.Ui.Layers.interfaces;
using Assets.src.Ui.Utils;
using src.Ui.Components.interfaces;
using UnityEngine;

namespace Assets.src.Ui.Factory
{
    internal sealed class LayerFactory
    {   
        private readonly IUiPrefabs _prefabs;
        private readonly WindowFactory _windowFactory;
        private readonly PopUpFactory _popUpFactory;
        
        public LayerFactory(IUiPrefabs prefabs,
                            WindowFactory windowFactory, 
                            PopUpFactory popUpFactory)
        {
            _prefabs = prefabs;
            _windowFactory = windowFactory;
            _popUpFactory = popUpFactory;
        }
        
        public ILayer GetWindows(Transform parent)
        {
            RectTransform container = _prefabs.Container(parent, UiConst.CONTAINER_WINDOW);
            container.gameObject.SetActive(true);
            Layer<IComponent> windows = new Layer<IComponent>(LayersTypes.Windows);

            windows.Add(UiConst.WINDOW_MAIN, _windowFactory.Menu(container));
            windows.Add(UiConst.WINDOW_GAME, _windowFactory.Game(container));
            
            return windows;
        }
        
        public ILayer GetPopup(Transform parent)
        {
            RectTransform container = _prefabs.Container(parent, UiConst.CONTAINER_POPUP);
            container.gameObject.SetActive(true);
            Layer<IComponent> popup = new Layer<IComponent>(LayersTypes.PopUp);

            popup.Add(UiConst.POPUP_TYPE1, _popUpFactory.PopUp(container));
            
            return popup;
        }
    }
}