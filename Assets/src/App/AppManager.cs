using Context.Mangers;
using Ui.Utils;
using Utils.Provider;

namespace App
{
    internal class AppManagerProvider : ProviderBase<AppManager, IAppManager>
    {

    }

    internal sealed class AppManager : IAppManager
    {
        public ContextManagers ContextManagers { get; }

        public AppManager()
        {
            ContextManagers = new ContextManagers();
        }

        public void Initialization()
        {
            ContextManagers.Initialization();
            ContextManagers.ManagerUi.Instance().SetActive(LayersTypes.Windows, UiConst.WINDOW_MAIN, true);
        }
    }
}