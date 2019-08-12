using src.Ui.Viewers;
using src.Ui.Viewers.Windows;
using UnityEngine;

namespace src.ScrObj.Ui.interfaces
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
