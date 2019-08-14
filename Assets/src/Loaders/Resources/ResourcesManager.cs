using Assets.src.ScrObj.Bots;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.ScrObj.Ui;
using Assets.src.ScrObj.Ui.interfaces;
using src.Loaders.Resources;

namespace Assets.src.Loaders.Resources
{
    public class ResourcesManager
    {
        private IUiPrefabs _uiPrefabs;
        private IBotsPull _botsPull;
        
        public void LoadResources()
        {
            _uiPrefabs = UnityEngine.Resources.Load<UiPrefabs>(ResourcesConst.UI_PREFABS_PATH);
            _botsPull = UnityEngine.Resources.Load<BotsPull>(ResourcesConst.BOTS_SETTINGS);
        }

        public IUiPrefabs GetUiPrefabs()
        {
            return _uiPrefabs;
        }
        
        public IBotsPull GetBots()
        {
            return _botsPull;
        }
    }
}
