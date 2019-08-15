using UnityEngine;

namespace Assets.src.App
{
    internal sealed class AppInitialization : MonoBehaviour
    {
        [SerializeField]
        private Canvas _uiCanvas;

        public void Start()
        {
            AppManager appManager = new AppManager(_uiCanvas);
            appManager.Initialization();
        }
    }
}