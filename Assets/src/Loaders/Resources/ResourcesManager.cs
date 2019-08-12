using Assets.src.ScrObj.Ui;
using Assets.src.ScrObj.Ui.interfaces;
using src.Loaders.Resources;

namespace Assets.src.Loaders.Resources
{
    public class ResourcesManager
    {
        private IUiPrefabs _uiPrefabs;

        public void LoadResources()
        {
            _uiPrefabs = UnityEngine.Resources.Load<UiPrefabs>(ResourcesConst.UI_PREFABS_PATH);
        }

        public IUiPrefabs GetUiPrefabs()
        {
            return _uiPrefabs;
        }
    }
}
