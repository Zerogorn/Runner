﻿using Assets.src.Loaders.Resources;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui;
using Assets.src.Ui.Factory;
using Assets.src.Ui.Models;
using Assets.src.Ui.Utils;
using src.Units.Bot;
using src.Units.Bot.Strategy;
using src.Units.Move;
using src.Units.Validator;
using UnityEngine;

namespace Assets.src.App
{
    public class AppManager
    {
        private readonly ResourcesManager _resourcesManager;
        private ModelContext _modelContext;

        private readonly MoveSimulation _moveSimulation;
        private readonly BotValidator _botValidator;
        
        private UiManger _uiManger;
        public  static Canvas _canvas;
        
        public AppManager()
        {
            _resourcesManager = new ResourcesManager();
            _moveSimulation = new MoveSimulation();
            _botValidator = new BotValidator();
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
            _canvas = uiPrefabs.Canvas();

            _modelContext = new ModelContext();
            WindowFactory windowFactory = new WindowFactory(uiPrefabs, _modelContext);
            PopUpFactory popUpFactory = new PopUpFactory(uiPrefabs, _modelContext);
            LayerFactory layerFactory = new LayerFactory(uiPrefabs, windowFactory, popUpFactory);

            _uiManger = new UiManger(_canvas, _modelContext, layerFactory);
            _uiManger.SetActive(LayersTypes.Windows ,UiConst.WINDOW_MAIN, true);
        }

        private void UIiBinding()
        {
            _modelContext.MenuModel.SubscribeStart(x =>
            {
                _uiManger.SetActive(LayersTypes.Windows,
                                    UiConst.WINDOW_GAME,
                                    true);
                
                _moveSimulation.Start();
                _botValidator.Start();
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
            PullMoveStrategy pullMoveStrategy = new PullMoveStrategy();

            BotsFactory botsFactory = new BotsFactory(pullMoveStrategy, bots);
            
            _modelContext.GameModel.AddBots(botsFactory.GetBots());
        }
        
        private void GameBinding()
        {
            _moveSimulation.Subscribe(_modelContext.GameModel.UpdatePositions);
            _botValidator.Subscribe(_modelContext.GameModel.ResetBots);
        }
    }
}
