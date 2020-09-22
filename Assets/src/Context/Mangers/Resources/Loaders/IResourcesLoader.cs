using UnityEngine;

namespace Context.Mangers.Resources.Loaders
{
    public interface IResourcesLoader
    {
        TObj Load<TObj>(string path)
            where TObj : Object;
    }
}