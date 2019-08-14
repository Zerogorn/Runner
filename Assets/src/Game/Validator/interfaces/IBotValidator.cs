using System;
using UniRx;

namespace src.Game.Validator.interfaces
{
	internal interface IBotValidator
	{
		IDisposable Subscribe(Action<Unit> action);
	}
}
