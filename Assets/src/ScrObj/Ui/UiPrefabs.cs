using src.ScrObj.Ui.interfaces;
using src.Ui;
using src.Ui.Viewers;
using UnityEngine;

namespace src.ScrObj.Ui
{
    [CreateAssetMenu(fileName = "UiPrefabs", menuName = "ScriptableObjects/UiPrefabs")]
    public class UiPrefabs : ScriptableObject, IUiPrefabs
    {
        [Header("Main Canvas")]
        [SerializeField]
        private Canvas _canvas;

        [Header("Menu Window")]
        [SerializeField]
        private MenuViewer _menuViewer;

        [SerializeField]
        [Header("PopUp")]
        private PopUpViewer _popUpViewer;

        [SerializeField]
        [Header("Game Container")]
        private GameContainerViewer _gameContainerViewer;

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
            menuViewer.name = UiConst.MAIN;

            return menuViewer;
        }

        public PopUpViewer Popup(Transform parent)
        {
            _popUpViewer.gameObject.SetActive(false);
            PopUpViewer popUpViewer = Instantiate(_popUpViewer, 
                                                  parent);
            popUpViewer.name = UiConst.POPUP_TYPE1;

            return popUpViewer;
        }

        public GameContainerViewer GameContainer(Transform parent)
        {
            _gameContainerViewer.gameObject.SetActive(false);
         
            GameContainerViewer gameContainerViewer = Instantiate(_gameContainerViewer,
                                                                  parent);
            gameContainerViewer.name = UiConst.GAME;

            return gameContainerViewer;
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
