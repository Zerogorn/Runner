using src.Ui.Components.Items;
using src.Ui.Components.Popups;
using src.Ui.Components.Windows.Game;
using src.Ui.Components.Windows.Menu;
using UnityEngine;

namespace Assets.src.ScrObj.Ui.interfaces
{
    internal interface IUiPrefabs
    {
        ButtonViewer ButtonDefault(Transform parent);
        MenuViewer Menu(Transform parent);
        PopUpViewer Popup(Transform parent);
        RectTransform Container(Transform parent, string containerCame);
    }
}
