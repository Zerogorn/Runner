using App;
using Context.Mangers.Resources;
using Context.Mangers.Ui.Layers;
using ScrObj.Ui.interfaces;
using Ui.Components.interfaces;
using Ui.Utils;
using UnityEngine;
using Utils.Container.interfaces;

namespace Ui.Factory
{
    internal sealed class LayerFactory
    {
        private readonly WindowFactory _windowFactory;
        private readonly PopUpFactory _popUpFactory;

        public LayerFactory(WindowFactory windowFactory,
                            PopUpFactory popUpFactory)
        {
            _windowFactory = windowFactory;
            _popUpFactory = popUpFactory;
        }

        private IContextContainer<ResourcesManager, IResourcesManager> resourcesManager => AppManagerProvider.Get().ContextManagers.ResourcesManager;

        public ILayer GetWindows(Transform parent)
        {
            IUiPrefabs prefabs = resourcesManager.Instance().UiPrefabs;
            RectTransform container = prefabs.Container(parent, UiConst.CONTAINER_WINDOW);
            container.gameObject.SetActive(true);
            Layer<IComponent> windows = new Layer<IComponent>(LayersTypes.Windows);

            windows.Add(UiConst.WINDOW_MAIN, _windowFactory.Menu(container));

            return windows;
        }

        public ILayer GetPopup(Transform parent)
        {
            IUiPrefabs prefabs = resourcesManager.Instance().UiPrefabs;
            RectTransform container = prefabs.Container(parent, UiConst.CONTAINER_POPUP);
            container.gameObject.SetActive(true);
            Layer<IComponent> popup = new Layer<IComponent>(LayersTypes.PopUp);

            popup.Add(UiConst.POPUP_TYPE1, _popUpFactory.PopUp(container));

            return popup;
        }
    }
}