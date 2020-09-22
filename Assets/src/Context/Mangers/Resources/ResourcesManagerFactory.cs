using Utils.Container;

namespace Context.Mangers.Resources
{
    internal class ResourcesManagerFactory
    {
        private readonly Container<ResourcesManager, IResourcesManager> _resourcesManagerContainer;
        private readonly ResourcesManager _managerCanvas;
        private readonly ResourcesManagerBinder _managerGameBinder;

        public ResourcesManagerFactory()
        {
            _resourcesManagerContainer = new Container<ResourcesManager, IResourcesManager>();
            _managerCanvas = new ResourcesManager();
            _managerGameBinder = new ResourcesManagerBinder(_managerCanvas);
        }

        public Container<ResourcesManager, IResourcesManager> Create()
        {
            _managerGameBinder.Bind();
            _resourcesManagerContainer.Swap(_managerCanvas);

            return _resourcesManagerContainer;
        }
    }
}