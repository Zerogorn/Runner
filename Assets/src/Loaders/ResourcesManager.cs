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
        private IGamePrefabs _gamePrefabs;
        
        public void LoadResources()
        {
            _uiPrefabs = Resources.Load<UiPrefabs>(ResourcesConst.UI_PREFABS_PATH);
            _gamePrefabs = Resources.Load<GamePrefabs>(ResourcesConst.GAME_PREFABS_PATH);
        }

        public IUiPrefabs GetUiPrefabs()
        {
            return _uiPrefabs;
        }
        
        public IGamePrefabs GetBots()
        {
            return _gamePrefabs;
        }
    }
}
