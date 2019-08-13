﻿using Assets.src.Loaders.Resources;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui;
using Assets.src.Ui.Factory;
using Assets.src.Ui.Models;
using Assets.src.Ui.Utils;
using src.Units.Bot;
using UnityEngine;

namespace Assets.src.App
{
    public class AppManager
    {
        private readonly ResourcesManager _resourcesManager;
        private readonly ModelContext _modelContext;
        
        private UiManger _uiManger;

        public AppManager()
        {
            _resourcesManager = new ResourcesManager();
            _modelContext = new ModelContext();
        }

        public void Initialization()
        {
            _resourcesManager.LoadResources();
            
            InitUi();
            UIiBinding();
            
            GameBinding();
            InitGame();
        }

        private void InitUi()
        {
            IUiPrefabs uiPrefabs = _resourcesManager.GetUiPrefabs();

            WindowFactory windowFactory = new WindowFactory(uiPrefabs, _modelContext);
            PopUpFactory popUpFactory = new PopUpFactory(uiPrefabs, _modelContext);
            LayerFactory layerFactory = new LayerFactory(uiPrefabs, windowFactory, popUpFactory);

            Canvas canvas = uiPrefabs.Canvas();
            _uiManger = new UiManger(canvas, _modelContext, layerFactory);
            _uiManger.SetActive(LayersTypes.Windows ,UiConst.WINDOW_MAIN, true);
        }

        private void UIiBinding()
        {
            _modelContext.MenuModel.SubscribeStart(x =>
            {
                _uiManger.SetActive(LayersTypes.Windows,
                                    UiConst.WINDOW_GAME,
                                    true);
            });

            _modelContext.PopUpModel.SubscribeToMenu(x =>
            {
                _uiManger.SetActive(LayersTypes.PopUp,
                                    UiConst.POPUP_TYPE1,
                                    false);
                _uiManger.SetActive(LayersTypes.Windows,
                                    UiConst.WINDOW_MAIN,
                                    true);
            });
            
            _modelContext.PopUpModel.SubscribeRepeat(x =>
            {
                _uiManger.SetActive(LayersTypes.PopUp,
                                    UiConst.POPUP_TYPE1,
                                    false);
                _uiManger.SetActive(LayersTypes.Windows,
                                    UiConst.WINDOW_GAME,
                                    true);
            });
        }

        private void InitGame()
        {
            IBotsSettingsCollection bots = _resourcesManager.GetBots();
            
            BotsFactory botsFactory = new BotsFactory(bots);
            _modelContext.GameModel.AddBots(botsFactory.GetBots());
        }
        
        private void GameBinding()
        {
            
        }
    }
}
