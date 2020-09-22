using Context.Mangers.interfaces;
using Context.Mangers.Resources.Loaders;

namespace Context.Mangers.Resources
{
    internal class ResourcesManagerBinder : IContextBinder
    {
        private ResourcesManager _resourcesManager;

        public ResourcesManagerBinder(ResourcesManager resourcesManager)
        {
            _resourcesManager = resourcesManager;
        }

        public void Bind()
        {
            _resourcesManager.Bind(new UnityResourcesLoader());
        }
    }
}