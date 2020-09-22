using Context.Mangers.Resources.Loaders;
using ScrObj.Bots;
using ScrObj.Bots.interfaces;
using ScrObj.Ui;
using ScrObj.Ui.interfaces;

namespace Context.Mangers.Resources
{
    internal sealed class ResourcesManager : IResourcesManager
    {
        private IResourcesLoader _resourcesLoader;

        public IUiPrefabs UiPrefabs { get; private set; }
        public IGamePrefabs GamePrefabs { get; private set; }

        public void Bind(IResourcesLoader resourcesLoader)
        {
            _resourcesLoader = resourcesLoader;
        }

        public void Initialization()
        {
            UiPrefabs = _resourcesLoader.Load<UiPrefabs>(ResourcesConst.UI_PREFABS_PATH);
            GamePrefabs = _resourcesLoader.Load<GamePrefabs>(ResourcesConst.GAME_PREFABS_PATH);
        }
    }
}
