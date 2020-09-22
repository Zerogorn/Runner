using Context.Mangers.interfaces;
using ScrObj.Bots.interfaces;
using ScrObj.Ui.interfaces;

namespace Context.Mangers.Resources
{
    internal interface IResourcesManager : IContextManager
    {
        IUiPrefabs UiPrefabs { get; }
        IGamePrefabs GamePrefabs { get;}
    }
}