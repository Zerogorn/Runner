using UnityEngine;

namespace src.App
{
    public class AppInitialization : MonoBehaviour
    {
        public void Start()
        {
            AppManager appManager = new AppManager();
            appManager.Initialization();
        }
    }
}