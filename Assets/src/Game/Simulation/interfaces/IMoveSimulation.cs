using System;

namespace src.Game.Simulation.interfaces
{
	internal interface IMoveSimulation
	{
		IDisposable SubscribeUpdate(Action<float> action);
	}
}
