using src.Ui.Mvc.Items;
using src.Ui.Mvc.Popups;
using src.Ui.Mvc.Windows;
using src.Ui.Mvc.Windows.Menu;
using src.Ui.Viewers;
using UnityEngine;

namespace src.ScrObj.Ui.interfaces
{
    public interface IUiPrefabs
    {
        Canvas Canvas();
        ButtonDefaultViewer ButtonDefault(Transform parent);
        MenuViewer Menu(Transform parent);
        PopUpViewer Popup(Transform parent);
        GameViewer GameContainer(Transform parent);
        RectTransform Container(Transform parent, string containerCame);
    }
}
