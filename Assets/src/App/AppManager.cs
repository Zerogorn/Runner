using Assets.src.Loaders.Resources;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui;
using Assets.src.Ui.Factory;
using Assets.src.Ui.Models;
using Assets.src.Ui.Utils;
using src.Units.Bot;
using src.Units.Bot.Strategy;
using src.Units.Simulation;
using src.Units.Validator;
using UnityEngine;

namespace Assets.src.App
{
    public class AppManager
    {
        private readonly ResourcesManager _resourcesManager;

        private readonly MoveSimulation _moveSimulation;
        private readonly BotValidator _botValidator;
        
        private readonly ModelContext _modelContext;
        private UiManger _uiManger;
        
        public AppManager()
        {
            _resourcesManager = new ResourcesManager();
            _modelContext = new ModelContext();
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
            Canvas canvas = uiPrefabs.Canvas();

            _modelContext.GameModel.Initialization(canvas);
            
            WindowFactory windowFactory = new WindowFactory(uiPrefabs, _modelContext);
            PopUpFactory popUpFactory = new PopUpFactory(uiPrefabs, _modelContext);
            LayerFactory layerFactory = new LayerFactory(uiPrefabs, windowFactory, popUpFactory);

            _uiManger = new UiManger(canvas, layerFactory);
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
                
                _moveSimulation.Start();
                _botValidator.Start();
            });
        }

        private void InitGame()
        {
            IBotsPull bots = _resourcesManager.GetBots();
            PullMoveStrategy pullMoveStrategy = new PullMoveStrategy();

            BotsFactory botsFactory = new BotsFactory(pullMoveStrategy, bots);
            
            _modelContext.GameModel.AddBots(botsFactory.GetBots());
        }
        
        private void GameBinding()
        {
            _moveSimulation.Subscribe(_modelContext.GameModel.UpdatePositions);
            _botValidator.Subscribe(_modelContext.GameModel.ResetBots);
            
            _modelContext.GameModel.AddCounterListener(() =>
            {
                _moveSimulation.Stop();
                _botValidator.Stop();
                
                _uiManger.SetActive(LayersTypes.PopUp,
                                    UiConst.POPUP_TYPE1,
                                    true);
            });
        }
    }
}
