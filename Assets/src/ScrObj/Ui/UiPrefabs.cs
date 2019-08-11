using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Viewers;
using UnityEngine;

namespace Assets.src.ScrObj.Ui
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
            return Instantiate(_menuViewer, 
                               parent);
        }

        public PopUpViewer Popup(Transform parent)
        {
            return Instantiate(_popUpViewer, 
                               parent);
        }

        public GameContainerViewer GameContainer(Transform parent)
        {
            return Instantiate(_gameContainerViewer,
                               parent);
        }

        public RectTransform Container(Transform parent, string containerCame)
        {
            RectTransform rect = Instantiate(_container,
                                             parent);

            rect.name = containerCame;

            return rect;
        }
    }
}
