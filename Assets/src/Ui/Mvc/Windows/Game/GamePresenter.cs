using Assets.src.Ui.Models;
using UniRx;
using UniRx.Triggers;

namespace Assets.src.Ui.Mvc.Windows.Game
{
	public class GamePresenter
	{
		private readonly GameViewer _gameViewer;
		private readonly GameModel _gameModel;

		public GamePresenter(GameViewer game
							 , GameModel gameModel)
		{
			_gameViewer = game;
			_gameModel = gameModel;

			Binding();
		}

		private void Binding()
		{
			_gameViewer.gameObject
					.OnEnableAsObservable()
					.Subscribe(_ =>
						{
							_gameViewer.AddBots(_gameModel.GetBots());
						});
		}
	}
}
