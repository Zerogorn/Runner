using src.ScrObj.Ui;
using src.ScrObj.Ui.interfaces;

namespace src.Loaders.Resources
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
