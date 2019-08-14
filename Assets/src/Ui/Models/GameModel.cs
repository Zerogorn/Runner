﻿using System;
using System.Collections.Generic;
using Assets.src.App;
using src.Units.Bot;
using UniRx;
using UnityEngine;

namespace Assets.src.Ui.Models
{
	internal sealed class GameModel
	{
		private readonly int _skipCounter;
		
		private readonly ReactiveProperty<int> _counter;
		private readonly ReactiveCollection<BotViewer> _bots;

		public GameModel()
		{
			_skipCounter = 3;
			
			_counter = new ReactiveProperty<int>();
			_bots = new ReactiveCollection<BotViewer>();
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

				_counter.Value = 0;
				ResetBots();
				action.Invoke();
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
		
		public void ResetBotsUnderCanvas(Unit unit)
		{
			IEnumerator<BotViewer> enumerator = _bots.GetEnumerator();

			while (enumerator.MoveNext())
			{
				BotViewer botViewer = enumerator.Current;
				
				if(botViewer == null)
					continue;

				bool overMoveY = botViewer.GetPosition().y
										.CompareTo(-AppManager.GetCanvasUtils.YMax)
										.Equals(-1);
				
				bool overMoveX = Mathf.Abs(botViewer.GetPosition().x)
										.CompareTo(AppManager.GetCanvasUtils.XMax)
										.Equals(1);
				
				if (overMoveY || overMoveX)
					botViewer.ResetPosition();

				if (overMoveY && !botViewer.GetTrap())
					_counter.Value++;

			}
			
			enumerator.Dispose();
		}

		public void HitBot(Vector3 presPosition)
		{
			presPosition = Camera.main.ScreenToViewportPoint(presPosition);

			float x = presPosition.x < 0.5f
				? (presPosition.x - 0.5f) * AppManager.GetCanvasUtils.Width
				: Mathf.Abs(0.5f - presPosition.x) * AppManager.GetCanvasUtils.Width;
			
			float y = presPosition.y < 0.5f
				? (presPosition.y - 0.5f) * AppManager.GetCanvasUtils.Height
				: Mathf.Abs(0.5f - presPosition.y) * AppManager.GetCanvasUtils.Height; 
			
			Vector2 xPointPosition = new Vector3(x, y);
			
			IEnumerator<BotViewer> enumerator = _bots.GetEnumerator();

			while (enumerator.MoveNext())
			{
				BotViewer botViewer = enumerator.Current;

				float deltaShootBot = Vector3.Distance(botViewer.GetPosition(), xPointPosition);

				if (Mathf.Abs(deltaShootBot) > botViewer.GetHitBox())
					continue;

				botViewer.ResetPosition();
				_counter.Value = botViewer.GetTrap() ? _skipCounter : _counter.Value;
			}
			
			enumerator.Dispose();
		}
		
		private void ResetBots()
		{
			IEnumerator<BotViewer> enumerator = _bots.GetEnumerator();

			while (enumerator.MoveNext())
			{
				enumerator.Current?.ResetPosition();
			}
			
			enumerator.Dispose();
		}
	}
}
