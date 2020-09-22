using System;
using UniRx;

namespace Game.Validator.interfaces
{
	internal interface IBotValidator
	{
		IDisposable Subscribe(Action<Unit> action);
	}
}
