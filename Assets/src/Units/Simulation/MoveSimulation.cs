using System;
using UniRx;
using UnityEngine;

namespace src.Units.Simulation
{
	internal sealed class MoveSimulation
	{ 
		private ReactiveProperty<float> Move { get; }
		
		private float _speed = 150;

		private IDisposable _disposable;
		
		public MoveSimulation()
		{
			Move = new ReactiveProperty<float>();
		}

		public void Start()
		{
			_disposable = Observable.EveryUpdate().Subscribe(_ => Update());
		}

		public void Stop()
		{
			_disposable.Dispose();
		}
		
		private void Update()
		{
			Move.SetValueAndForceNotify(_speed * Time.deltaTime);
		}

		public IDisposable Subscribe(Action<float> action)
		{
			return Move.Subscribe(action);
		}
	}
}
