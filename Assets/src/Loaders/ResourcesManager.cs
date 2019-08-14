using Assets.src.ScrObj.Bots;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.ScrObj.Ui;
using Assets.src.ScrObj.Ui.interfaces;
using UnityEngine;

namespace src.Loaders
{
    internal sealed class ResourcesManager
    {
        private IUiPrefabs _uiPrefabs;
        private IBotsPull _botsPull;
        
        public void LoadResources()
        {
            _uiPrefabs = Resources.Load<UiPrefabs>(ResourcesConst.UI_PREFABS_PATH);
            _botsPull = Resources.Load<BotsPull>(ResourcesConst.BOTS_SETTINGS);
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
