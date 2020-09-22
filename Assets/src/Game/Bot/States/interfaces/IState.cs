namespace Game.Bot.States.interfaces
{
    internal interface IState
    {
        bool Trap { get; }
        int HitBoxRadius { get; }

        IState Update();
    }
}
