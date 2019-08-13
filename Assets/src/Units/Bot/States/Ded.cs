using Assets.src.Units.Bot.interfaces;

namespace src.Units.Bot.States
{
	public class Ded : IState
	{
		public IState Update()
		{
			return new Live();
		}
	}
}
