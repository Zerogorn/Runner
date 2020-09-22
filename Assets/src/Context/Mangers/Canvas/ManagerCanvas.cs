using App;
using Context.Mangers.interfaces;
using Context.Mangers.Resources;
using UnityEngine;
using Utils.Container.interfaces;

namespace Context.Mangers.Canvas
{
    internal sealed class ManagerCanvas : IContextManager, IManagerCanvas
    {
        private const string UiCanvas = "UiCanvas";
        
        public UnityEngine.Canvas CurrentСanvas { get; private set; }

        public float Height { get; private set; }
        public float Width { get; private set; }
        public float XMax { get; private set; }
        public float YMax { get; private set; }

        private IContextContainer<ResourcesManager, IResourcesManager> _resourcesManager => AppManagerProvider.Get().ContextManagers.ResourcesManager;

        public void Initialization()
        {
            CurrentСanvas = _resourcesManager.Instance().UiPrefabs.Canvas(UiCanvas);
            CurrentСanvas.worldCamera = Camera.main;

            Height = Screen.height / CurrentСanvas.scaleFactor;
            Width = Screen.width / CurrentСanvas.scaleFactor;

            XMax = Width * 0.5f;
            YMax = Height * 0.5f;
        }
    }
}