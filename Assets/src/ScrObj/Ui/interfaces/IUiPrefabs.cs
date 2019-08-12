using Assets.src.Ui.Mvc.Items;
using Assets.src.Ui.Mvc.Popups;
using Assets.src.Ui.Mvc.Windows.Game;
using Assets.src.Ui.Mvc.Windows.Menu;
using UnityEngine;

namespace Assets.src.ScrObj.Ui.interfaces
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
