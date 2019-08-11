using Assets.src.Viewers;
using UnityEngine;

namespace Assets.src.ScrObj.Ui.interfaces
{
    public interface IUiPrefabs
    {
        Canvas Canvas();
        MenuViewer Menu();
        PopUpViewer Popup();
        GameContainerViewer GameContainer();
    }
}
