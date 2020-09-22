using UnityEngine;

namespace Context.Mangers.Resources.Loaders
{
    public sealed class UnityResourcesLoader : IResourcesLoader
    {
        public TObj Load<TObj>(string path)
            where TObj : Object
        {
            return UnityEngine.Resources.Load<TObj>(path);
        }
    }
}