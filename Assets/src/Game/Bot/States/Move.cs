using Assets.src.Game.Bot.States.interfaces;

namespace Assets.src.Game.Bot.States
{
    internal sealed class Move : IState
    {
        public bool Trap { get; }
        public int HitBoxRadius { get; }

        public Move(bool trap
                    , int hitBoxRadius)
        {
            Trap = trap;
            HitBoxRadius = hitBoxRadius;
        }

        public IState Update()
        {
            return new Ded(Trap, HitBoxRadius);
        }
    }
}
