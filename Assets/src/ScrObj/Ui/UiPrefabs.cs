using ScrObj.Ui.interfaces;
using Ui.Components.Items;
using Ui.Components.Popups;
using Ui.Components.Windows.Menu;
using Ui.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScrObj.Ui
{
    [CreateAssetMenu(fileName = "UiPrefabs", menuName = "ScriptableObjects/UiPrefabs")]
    internal sealed class UiPrefabs : ScriptableObject, 
                                      IUiPrefabs
    {
        [FormerlySerializedAs("_buttonDefault")]
        [SerializeField]
        [Header("Button Default")]
        private ButtonViewer _button;

        [Header("Menu Window")]
        [SerializeField]
        private MenuViewer _menuViewer;

        [SerializeField]
        [Header("PopUp")]
        private PopUpViewer _popUpViewer;

        [SerializeField]
        [Header("Container")]
        private RectTransform _container;

        [SerializeField]
        [Header("Container")]
        private Canvas _canvasUi;

        public MenuViewer Menu(Transform parent)
        {
            MenuViewer menuViewer = Instantiate(_menuViewer, parent);
            menuViewer.name = UiConst.WINDOW_MAIN;

            return menuViewer;
        }

        public ButtonViewer ButtonDefault(Transform parent)
        {
            ButtonViewer button = Instantiate(_button, parent);
            button.name = UiConst.BUTTON;

            return button;
        }

        public PopUpViewer Popup(Transform parent)
        {
            PopUpViewer popUpViewer = Instantiate(_popUpViewer, parent);
            popUpViewer.name = UiConst.POPUP_TYPE1;

            return popUpViewer;
        }

        public RectTransform Container(Transform parent,
                                       string containerCame)
        {
            RectTransform rect = Instantiate(_container, parent);
            rect.name = containerCame;

            return rect;
        }

        public Canvas Canvas(string containerCame)
        {
            Canvas canvas = Instantiate(_canvasUi);
            canvas.name = containerCame;

            return canvas;
        }
    }
}
