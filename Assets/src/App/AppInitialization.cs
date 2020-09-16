using UnityEngine;

namespace Assets.src.App
{
    internal sealed class AppInitialization : MonoBehaviour
    {
        [SerializeField]
        private Canvas _uiCanvas;

        private AppManager _appManager;

        private void Awake()
        {
            _appManager = new AppManager(_uiCanvas);
        }

        public void Start()
        {
            _appManager.Initialization();
        }
    }
}