using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui.Models;
using Assets.src.Ui.Mvc.Windows.Game;
using Assets.src.Ui.Mvc.Windows.Menu;
using UnityEngine;

namespace Assets.src.Ui.Factory
{
	public class WindowFactory
	{
		private readonly IUiPrefabs _uiPrefabs;
		private readonly ModelContext _modelContext;
		
		public WindowFactory(IUiPrefabs uiPrefabs, ModelContext modelContext)
		{
			_uiPrefabs = uiPrefabs;
			_modelContext = modelContext;
		}
		
		public MenuViewer Menu(Transform parent)
		{
			MenuViewer menuViewer = _uiPrefabs.Menu(parent);
            menuViewer.Initialization(_uiPrefabs);

            MenuModel menuModel = _modelContext.MenuModel;
            MenuPresenter presenter = new MenuPresenter(menuViewer, menuModel);
			
			return menuViewer;
		}
		
		public GameViewer Game(Transform parent)
		{
			GameViewer game = _uiPrefabs.GameContainer(parent);
			GameModel gameModel = _modelContext.GameModel;
			
			GamePresenter presenter = new GamePresenter(game, gameModel);
			
			return game;
		}
	}
}
