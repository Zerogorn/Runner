using Assets.src.Game;
using Assets.src.Game.Bot;
using Assets.src.Game.Bot.Strategy;
using Assets.src.Game.Simulation;
using Assets.src.Game.Validator;
using Assets.src.Loaders;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui;
using Assets.src.Ui.Factory;
using Assets.src.Ui.Models;
using Assets.src.Ui.Utils;
using UnityEngine;

namespace Assets.src.App
{
    internal sealed class AppManager
    {
        public static CanvasUtils GetCanvasUtils { get; private set; }

        private readonly ResourcesManager _resourcesManager;
        private readonly ModelContext _modelContext;

        // todo remove to model.
        private IUiPrefabs _uiPrefabs;
        private IGamePrefabs _gamePrefabs;
        //

        private UiManger _uiManger;
        private GameManager _gameManager;

        private AppManager()
        {
            _resourcesManager = new ResourcesManager();
            _modelContext = new ModelContext();
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
            _gamePrefabs = _resourcesManager.GetBots();
        }

        #region Ui

        private void InitUi()
        {
            WindowFactory windowFactory = new WindowFactory(_uiPrefabs, _modelContext);
            PopUpFactory popUpFactory = new PopUpFactory(_uiPrefabs, _modelContext);
            LayerFactory layerFactory = new LayerFactory(_uiPrefabs, windowFactory, popUpFactory);

            _uiManger = new UiManger(GetCanvasUtils.UiCanvas, layerFactory);

            _uiManger.SetActive(LayersTypes.Windows, UiConst.WINDOW_MAIN, true);
        }

        private void UIiBinding()
        {
            _modelContext.MenuModel.SubscribeStart(x =>
            {
                _uiManger.HideOpenWindows();

                _gameManager.StartGame();
            });

            _modelContext.PopUpModel.SubscribeToMenu(x =>
            {
                _uiManger.HideOpenPopup();

                _uiManger.SetActive(LayersTypes.Windows, UiConst.WINDOW_MAIN, true);
            });

            _modelContext.PopUpModel.SubscribeRepeat(x =>
            {
                _uiManger.HideOpenPopup();

                _gameManager.StartGame();
            });
        }

        #endregion End Ui

        #region Game

        private void InitGame()
        {
            MoveSimulation moveSimulation = new MoveSimulation();
            BotValidator botValidator = new BotValidator();

            PullMoveStrategy pullMoveStrategy = new PullMoveStrategy();
            GameFactory gameFactory = new GameFactory(_modelContext, pullMoveStrategy, _gamePrefabs);

            _gameManager = new GameManager(_modelContext, moveSimulation, botValidator, gameFactory);
        }

        private void GameBinding()
        {
            _gameManager.GetMoveSimulation()
                        .SubscribeUpdate(_modelContext.GameModel.UpdateBotPositions);

            _gameManager.GetBotValidator()
                        .Subscribe(_modelContext.GameModel.ResetBotsUnderCanvas);

            _modelContext.GameModel.AddLoseCounterListener(() =>
            {
                _gameManager.StopGame();

                _uiManger.SetActive(LayersTypes.PopUp, UiConst.POPUP_TYPE1, true);
            });
        }

        #endregion End Game
    }
}
