using System;
using src.Game.Simulation.interfaces;
using UniRx;
using UnityEngine;

namespace src.Units.Simulation
{
	internal sealed class MoveSimulation : IMoveSimulation
	{
		private ReactiveProperty<float> LastUpdate { get; }

		private float _speed = 150;

		private IDisposable _disposable;

		public MoveSimulation()
		{
			LastUpdate = new ReactiveProperty<float>();
		}

		public void Start()
		{
			_disposable = Observable.EveryUpdate()
								 .Subscribe(_ => Update());
		}

		public void Stop()
		{
			_disposable?.Dispose();
		}

		private void Update()
		{
			LastUpdate.SetValueAndForceNotify(_speed * Time.deltaTime);
		}

		public IDisposable SubscribeUpdate(Action<float> action)
		{
			return LastUpdate.Subscribe(action);
		}
	}
}
