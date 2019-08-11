﻿using Assets.src.ScrObj.Ui.interfaces;
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
            return Instantiate(_canvas);
        }

        public MenuViewer Menu(RectTransform parent)
        {
            return Instantiate(_menuViewer, parent);
        }

        public PopUpViewer Popup(RectTransform parent)
        {
            return Instantiate(_popUpViewer, parent);
        }

        public GameContainerViewer GameContainer(RectTransform parent)
        {
            return Instantiate(_gameContainerViewer, parent);
        }
    }
}
