using Assets.src.Const;
using Assets.src.ScrObj.Ui;
using Assets.src.ScrObj.Ui.interfaces;
using UnityEngine;

namespace Assets.src.Managers
{
    public class ResourcesManager
    {
        private IUiPrefabs _uiPrefabs;

        public void LoadResources()
        {
            _uiPrefabs = Resources.Load<UiPrefabs>(ResourcesConst.UI_PREFABS_PATH);
        }

        public IUiPrefabs GetUiPrefabs()
        {
            return _uiPrefabs;
        }
    }
}
