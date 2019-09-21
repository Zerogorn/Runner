using Assets.src.Game.Bot.States.interfaces;

namespace Assets.src.Game.Bot.States
{
    internal sealed class Ded : IState
    {
        public bool Trap { get; }
        public int HitBoxRadius { get; }

        public Ded(bool trap
                   , int hitBoxRadius)
        {
            Trap = trap;
            HitBoxRadius = hitBoxRadius;
        }

        public IState Update()
        {
            return new Move(Trap, HitBoxRadius);
        }
    }
}
