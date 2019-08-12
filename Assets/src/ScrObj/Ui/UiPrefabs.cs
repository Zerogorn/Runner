using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui.Mvc.Items;
using Assets.src.Ui.Mvc.Popups;
using Assets.src.Ui.Mvc.Windows.Game;
using Assets.src.Ui.Mvc.Windows.Menu;
using Assets.src.Ui.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.src.ScrObj.Ui
{
    [CreateAssetMenu(fileName = "UiPrefabs", menuName = "ScriptableObjects/UiPrefabs")]
    public class UiPrefabs : ScriptableObject, IUiPrefabs
    {
        [Header("Main Canvas")]
        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        [Header("Button Default")]
        private ButtonDefaultViewer _buttonDefault;
        
        [Header("Menu Window")]
        [SerializeField]
        private MenuViewer _menuViewer;

        [SerializeField]
        [Header("PopUp")]
        private PopUpViewer _popUpViewer;

        [FormerlySerializedAs("_gameContainerViewer")]
        [SerializeField]
        [Header("Game Container")]
        private GameViewer _gameViewer;

        [SerializeField]
        [Header("Container")]
        private RectTransform _container;

        public Canvas Canvas()
        {
            return Instantiate(_canvas);
        }

        public MenuViewer Menu(Transform parent)
        {
            _menuViewer.gameObject.SetActive(false);
            
            MenuViewer menuViewer = Instantiate(_menuViewer,
                                                parent);
            menuViewer.name = UiConst.WINDOW_MAIN;

            return menuViewer;
        }

        public ButtonDefaultViewer ButtonDefault(Transform parent)
        {
            _buttonDefault.gameObject.SetActive(false);
            ButtonDefaultViewer button = Instantiate(_buttonDefault, 
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

        public GameViewer GameContainer(Transform parent)
        {
            _gameViewer.gameObject.SetActive(false);
         
            GameViewer gameViewer = Instantiate(_gameViewer,
                                                                  parent);
            gameViewer.name = UiConst.WINDOW_GAME;

            return gameViewer;
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
