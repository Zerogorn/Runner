using src.ScrObj.Ui.interfaces;
using src.Ui.interfaces;
using src.Ui.Layers.interfaces;
using src.Ui.Viewers.Windows.interfaces;
using UnityEngine;

namespace src.Ui.Layers
{
    public class LayerFactory
    {   
        private readonly IUiPrefabs _prefabs;
        
        public LayerFactory(IUiPrefabs prefabs)
        {
            _prefabs = prefabs;
        }
        
        public ILayer GetWindows(Transform parent)
        {
            RectTransform container = _prefabs.Container(parent, UiConst.CONTAINER_WINDOW);
            Layer<WindowTypes, IWindow> windows = new Layer<WindowTypes, IWindow>(LayersTypes.Windows, container);

            windows.Add(WindowTypes.Menu, _prefabs.Menu(container));
            windows.Add(WindowTypes.Game, _prefabs.GameContainer(container));
            
            return windows;
        }
        
        public ILayer GetPopup(Transform parent)
        {
            RectTransform container = _prefabs.Container(parent, UiConst.CONTAINER_POPUP);
            Layer<PopUpTypes, IPopUp> popup = new Layer<PopUpTypes, IPopUp>(LayersTypes.PopUp, container);

            popup.Add(PopUpTypes.Type1, _prefabs.Popup(container));
            
            return popup;
        }
    }
}