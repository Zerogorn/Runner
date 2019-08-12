using src.Ui.Models;

namespace src.Ui
{
	public class ModelContext
	{
		public MenuModel MenuModel { get; }
		public GameModel GameModel { get; }
		public PopUpModel PopUpModel { get; }
		
		public ModelContext()
		{
			MenuModel = new MenuModel();
			GameModel = new GameModel();
			PopUpModel = new PopUpModel();
		}
	}
}
