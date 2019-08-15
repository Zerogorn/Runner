namespace Assets.src.Units.Bot.interfaces
{
    internal interface IState
    {
        bool Trap { get; }
        int HitBoxRadius { get; }

        IState Update();
    }
}
