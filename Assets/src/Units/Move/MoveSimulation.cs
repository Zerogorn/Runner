using System;
using UniRx;
using UnityEngine;

namespace src.Units.Move
{
	public class MoveSimulation
	{ 
		private ReactiveProperty<float> Move { get; }

		private int _vector;
		private float _speed = 100;

		private IDisposable _disposable;
		
		public MoveSimulation()
		{
			Move = new ReactiveProperty<float>();
		}

		public void Start(int vector)
		{
			_vector = vector;
			_disposable = Observable.EveryUpdate().Subscribe(_ => Update());
		}

		public void Stop()
		{
			_disposable.Dispose();
		}
		
		private void Update()
		{
			Move.SetValueAndForceNotify(_vector *(_speed * Time.deltaTime));
		}

		public IDisposable Subscribe(Action<float> action)
		{
			return Move.Subscribe(action);
		}
	}
}
