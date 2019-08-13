using System;
using System.Collections.Generic;
using src.Units.Bot;
using UniRx;
using UnityEngine;

namespace Assets.src.Ui.Models
{
	public class GameModel
	{
		private readonly int _skipCounter;
		
		private readonly ReactiveProperty<int> _counter;
		private readonly ReactiveCollection<BotViewer> _bots;

		private float _yMax;
		private float _xMax;
		
		public GameModel()
		{
			_skipCounter = 3;
			
			_counter = new ReactiveProperty<int>();
			_bots = new ReactiveCollection<BotViewer>();
		}

		public void Initialization(Canvas canvas)
		{
			_yMax = Screen.height / canvas.scaleFactor;
			_xMax = Screen.width / canvas.scaleFactor;			
		}
		
		public void AddBots(IEnumerable<BotViewer> bots)
		{
			IEnumerator<BotViewer> enumerator = bots.GetEnumerator();

			while (enumerator.MoveNext())
				_bots.Add(enumerator.Current);
			
			enumerator.Dispose();
		}

		public void AddCounterListener(Action action)
		{
			_counter.Skip(1).Subscribe(x =>
			{
				if (x < _skipCounter)
					return;

				action.Invoke();
				_counter.Value = 0;
			});
		}
		
		public IReactiveCollection<BotViewer> GetBots()
		{
			return _bots;
		}

		public void UpdatePositions(float move)
		{
			IEnumerator<BotViewer> enumerator = _bots.GetEnumerator();

			while (enumerator.MoveNext())
				enumerator.Current?.UpdatePosition(move);
			
			enumerator.Dispose();
		}

		public void ResetBots(Unit unit)
		{
			IEnumerator<BotViewer> enumerator = _bots.GetEnumerator();

			while (enumerator.MoveNext())
			{
				if(enumerator.Current == null)
					continue;

				bool overMoveY = enumerator.Current.GetPosition().y
										.CompareTo(-_yMax * 0.5f)
										.Equals(-1);
				
				bool overMoveX = Mathf.Abs(enumerator.Current.GetPosition().x)
										.CompareTo(_xMax * 0.5f)
										.Equals(1);
				
				if (overMoveY || overMoveX)
					enumerator.Current.ResetPosition();
			}
			
			enumerator.Dispose();
		}

		public void HitBot(Vector3 presPosition)
		{
			presPosition = Camera.main.ScreenToViewportPoint(presPosition);

			float x = presPosition.x < 0.5f
				? (presPosition.x - 0.5f) * _xMax
				: Mathf.Abs(0.5f - presPosition.x) * _xMax;
			
			float y = presPosition.y < 0.5f
				? (presPosition.y - 0.5f) * _yMax
				: Mathf.Abs(0.5f - presPosition.y) * _yMax; 
			
			Vector2 xPointPosition = new Vector3(x, y);
			
			IEnumerator<BotViewer> enumerator = _bots.GetEnumerator();

			while (enumerator.MoveNext())
			{
				BotViewer botViewer = enumerator.Current;

				float deltaShootBot = Vector3.Distance(botViewer.GetPosition(), xPointPosition);

				if (Mathf.Abs(deltaShootBot) > botViewer.GetHitBox())
					continue;

				botViewer.ResetPosition();
				_counter.Value = botViewer.GetTrap() ?_skipCounter : _counter.Value++;
			}
			
			enumerator.Dispose();
		}
	}
}
