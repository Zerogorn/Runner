using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui;
using Assets.src.Ui.Factory;
using Assets.src.Ui.Models;
using Assets.src.Ui.Utils;
using src;
using src.Loaders;
using src.Units.Bot;
using src.Units.Bot.Strategy;
using src.Units.Simulation;
using src.Units.Validator;
using UnityEngine;

namespace Assets.src.App
{
    internal sealed class AppManager
    {
        public static CanvasUtils GetCanvasUtils { get; private set; }

        private readonly ResourcesManager _resourcesManager;
        private readonly MoveSimulation _moveSimulation;
        private readonly BotValidator _botValidator;        
        private readonly ModelContext _modelContext;
        
        private IUiPrefabs _uiPrefabs;
        private IBotsPull _bots;
        
        private UiManger _uiManger;

        private AppManager()
        {
            
            _resourcesManager = new ResourcesManager();
            _modelContext = new ModelContext();
            _moveSimulation = new MoveSimulation();
            _botValidator = new BotValidator();
        }
        
        public AppManager(Canvas uiCanvas)
            : this()
        {
            GetCanvasUtils = new CanvasUtils(uiCanvas);
        }

        public void Initialization()
        {
            InitBase();
            
            InitUi();
            UIiBinding();
            
            InitGame();
            GameBinding();
        }

        private void InitBase()
        {
            _resourcesManager.LoadResources();
            _uiPrefabs = _resourcesManager.GetUiPrefabs();
            _bots = _resourcesManager.GetBots();
        }
        
#region Ui

        private void InitUi()
        {            
            WindowFactory windowFactory = new WindowFactory(_uiPrefabs, _modelContext);
            PopUpFactory popUpFactory = new PopUpFactory(_uiPrefabs, _modelContext);
            LayerFactory layerFactory = new LayerFactory(_uiPrefabs, windowFactory, popUpFactory);

            _uiManger = new UiManger(GetCanvasUtils.UiCanvas, layerFactory);
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
        
#endregion End Ui
        
#region Game
        
        private void InitGame()
        {
            PullMoveStrategy pullMoveStrategy = new PullMoveStrategy();
            BotsFactory botsFactory = new BotsFactory(pullMoveStrategy, _bots);
            
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
        
#endregion End Game
        
    }
}
