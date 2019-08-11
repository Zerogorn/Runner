using Assets.src.Viewers;
using UnityEngine;

namespace Assets.src.ScrObj.Ui.interfaces
{
    public interface IUiPrefabs
    {
        Canvas Canvas();
        MenuViewer Menu(Transform parent);
        PopUpViewer Popup(Transform parent);
        GameContainerViewer GameContainer(Transform parent);
        RectTransform Container(Transform parent, string containerCame);
    }
}
