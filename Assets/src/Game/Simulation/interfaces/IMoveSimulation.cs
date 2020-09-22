using System;

namespace Game.Simulation.interfaces
{
	internal interface IMoveSimulation
	{
		IDisposable SubscribeUpdate(Action<float> action);
	}
}
