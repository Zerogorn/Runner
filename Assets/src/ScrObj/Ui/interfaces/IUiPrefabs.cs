using Assets.src.Viewers;
using UnityEngine;

namespace Assets.src.ScrObj.Ui.interfaces
{
    public interface IUiPrefabs
    {
        Canvas Canvas();
        MenuViewer Menu(RectTransform parent);
        PopUpViewer Popup(RectTransform parent);
        GameContainerViewer GameContainer(RectTransform parent);
    }
}
