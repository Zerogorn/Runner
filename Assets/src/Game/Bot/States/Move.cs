using Assets.src.Units.Bot.interfaces;

namespace src.Units.Bot.States
{
	internal sealed class Move : IState
	{
		public IState Update()
		{
			return new Ded();
		}
	}
}
