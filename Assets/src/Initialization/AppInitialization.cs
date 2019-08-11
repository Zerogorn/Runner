using Assets.src.Managers;
using UnityEngine;

namespace Assets.src.Initialization
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
