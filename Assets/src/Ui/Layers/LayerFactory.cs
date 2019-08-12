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
            Layer<IWindow> windows = new Layer<IWindow>(container);

            windows.Add(_prefabs.Menu(container));
            windows.Add(_prefabs.GameContainer(container));
            
            return windows;
        }
        
        public ILayer GetPopup(Transform parent)
        {
            RectTransform container = _prefabs.Container(parent, UiConst.CONTAINER_POPUP);
            Layer<IPopUp> popup = new Layer<IPopUp>(container);

            popup.Add(_prefabs.Popup(container));
            
            return popup;
        }
    }
}