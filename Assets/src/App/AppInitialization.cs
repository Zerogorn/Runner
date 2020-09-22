using UnityEngine;

namespace App
{
    internal sealed class AppInitialization : MonoBehaviour
    {
        public void Start()
        {
            AppManagerProvider.Get().Initialization();
        }
    }
}