﻿using Assets.src.Ui.Models;

namespace Assets.src.Ui.Mvc.Windows.Menu
{
    public class MenuPresenter 
    {
        private readonly MenuViewer _menuViewer;
        private readonly MenuModel _menuModel;
        
        public MenuPresenter(MenuViewer menuViewer, MenuModel menuModel)
        {
            _menuViewer = menuViewer;
            _menuModel = menuModel;

            Binding();
        }

        private void Binding()
        {
            _menuViewer.ButtonStart.SetListener(_ => _menuModel.StartExecute());
            _menuModel.SubscribeStartText(_menuViewer.ButtonStart.SetText);
        }
    }
}
