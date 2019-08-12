using System.Collections.Generic;
using src.ScrObj.Ui.interfaces;
using src.Ui.interfaces;
using UnityEngine;

namespace src.Ui
{
    public class UiManger
    {
        private IUiPrefabs _uiPrefabs;

        private Canvas _canvas;
        private Transform _window;
        private Transform _popup;

        private readonly IList<KeyValuePair<Window, IWindow>> _windows;
        private readonly IList<KeyValuePair<PopUp, IPopUp>> _popUps;


        public UiManger()
        {
            _windows = new List<KeyValuePair<Window, IWindow>>();
            _popUps = new List<KeyValuePair<PopUp, IPopUp>>();
        }

        public void Initialization(IUiPrefabs uiPrefabs)
        {
            _uiPrefabs = uiPrefabs;

            Canvas();
            Windows();
            Popups();
        }

        private void Canvas()
        {
            _canvas = _uiPrefabs.Canvas();
            _canvas.worldCamera = Camera.main;

        }

        private void Windows()
        {
            _window = _uiPrefabs.Container(_canvas.transform, UiConst.CONTAINER_WINDOW);
            _windows.Add(GetWindow(Window.Menu, _uiPrefabs.Menu(_window)));
            _windows.Add(GetWindow(Window.Game, _uiPrefabs.GameContainer(_window)));
        }

        private void Popups()
        {
            _popup = _uiPrefabs.Container(_canvas.transform, UiConst.CONTAINER_POPUP);
            _popUps.Add(GetPopup(PopUp.Popup, _uiPrefabs.Popup(_popup)));
        }

        private KeyValuePair<Window, IWindow> GetWindow(Window key, IWindow window)
        {
            window.SetEnable(false);
            return new KeyValuePair<Window, IWindow>(key, window);
        }

        private KeyValuePair<PopUp, IPopUp> GetPopup(PopUp key, IPopUp popUp)
        {
            popUp.SetEnable(false);
            return new KeyValuePair<PopUp, IPopUp>(key, popUp);
        }
    }
}
