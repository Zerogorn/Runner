using UnityEngine;

namespace Assets.src.App
{
    internal sealed class AppInitialization : MonoBehaviour
    {
        public void Start()
        {
            AppManager appManager = new AppManager();
            appManager.Initialization();
        }
    }
}