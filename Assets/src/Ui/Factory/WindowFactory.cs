using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui.Models;
using src.Ui.Components.Windows.Game;
using src.Ui.Components.Windows.Menu;
using UnityEngine;

namespace Assets.src.Ui.Factory
{
	internal sealed class WindowFactory
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
	}
}
