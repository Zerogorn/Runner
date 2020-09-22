using Ui.Components.Items;
using Ui.Components.Popups;
using Ui.Components.Windows.Menu;
using UnityEngine;

namespace ScrObj.Ui.interfaces
{
    internal interface IUiPrefabs
    {
        ButtonViewer ButtonDefault(Transform parent);
        MenuViewer Menu(Transform parent);
        PopUpViewer Popup(Transform parent);

        RectTransform Container(Transform parent,
                                string containerCame);
        Canvas Canvas(string containerCame);
    }
}
