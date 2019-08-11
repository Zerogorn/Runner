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

        public Canvas Canvas()
        {
            return _canvas;
        }

        public MenuViewer Menu()
        {
            return _menuViewer;
        }

        public PopUpViewer Popup()
        {
            return _popUpViewer;
        }

        public GameContainerViewer GameContainer()
        {
            return _gameContainerViewer;
        }
    }
}
