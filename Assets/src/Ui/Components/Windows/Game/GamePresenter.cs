using Assets.src.Ui.Models;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace src.Ui.Components.Windows.Game
{
	internal sealed class GamePresenter
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
			_gameViewer.gameObject.AddComponent<ObservablePointerDownTrigger>()
						.OnPointerDownAsObservable()
						.Subscribe(x =>
						{
							_gameModel.HitBot(Input.mousePosition);
						});
		}
	}
}
