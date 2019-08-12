using src.Ui.Models;

namespace src.Ui.Mvc.Windows.Game
{
	public class GamePresenter
	{
		private readonly GameViewer _game;
		private readonly GameModel _gameModel;

		public GamePresenter(GameViewer game
							 , GameModel gameModel)
		{
			_game = game;
			_gameModel = gameModel;
		}
	}
}
