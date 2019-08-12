using src.Loaders.Resources;
using src.Ui;

namespace src.App
{
    public class AppManager
    {
        private readonly ResourcesManager _resourcesManager;
        private readonly UiManger _uiManger;

        public AppManager()
        {
            _resourcesManager = new ResourcesManager();
            _uiManger = new UiManger();
        }

        public void Initialization()
        {
            _resourcesManager.LoadResources();
            _uiManger.Initialization(_resourcesManager.GetUiPrefabs());
        }
    }
}
