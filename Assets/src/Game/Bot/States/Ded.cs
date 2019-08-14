using Assets.src.Units.Bot.interfaces;

namespace src.Units.Bot.States
{
	internal sealed class Ded : IState
	{
		public IState Update()
		{
			return new Move();
		}
	}
}
