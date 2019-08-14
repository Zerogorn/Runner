using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui.Utils;
using src.Ui.Components.Items;
using src.Ui.Components.Popups;
using src.Ui.Components.Windows.Game;
using src.Ui.Components.Windows.Menu;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.src.ScrObj.Ui
{
    [CreateAssetMenu(fileName = "UiPrefabs", menuName = "ScriptableObjects/UiPrefabs")]
    internal sealed class UiPrefabs : ScriptableObject, IUiPrefabs
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

        public MenuViewer Menu(Transform parent)
        {
            _menuViewer.gameObject.SetActive(false);
            
            MenuViewer menuViewer = Instantiate(_menuViewer,
                                                parent);
            menuViewer.name = UiConst.WINDOW_MAIN;

            return menuViewer;
        }

        public ButtonViewer ButtonDefault(Transform parent)
        {
            _button.gameObject.SetActive(false);
            ButtonViewer button = Instantiate(_button, 
                                                  parent);
            button.name = UiConst.BUTTON;

            return button;
        }
        
        public PopUpViewer Popup(Transform parent)
        {
            _popUpViewer.gameObject.SetActive(false);
            PopUpViewer popUpViewer = Instantiate(_popUpViewer, 
                                                  parent);
            popUpViewer.name = UiConst.POPUP_TYPE1;

            return popUpViewer;
        }

        public RectTransform Container(Transform parent, string containerCame)
        {
            _container.gameObject.SetActive(false);
          
            RectTransform rect = Instantiate(_container,
                                             parent);
            rect.name = containerCame;

            return rect;
        }
    }
}
