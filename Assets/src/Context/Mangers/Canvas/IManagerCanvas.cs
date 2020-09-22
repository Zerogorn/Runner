using Context.Mangers.interfaces;

namespace Context.Mangers.Canvas
{
    public interface IManagerCanvas : IContextManager
    {
        UnityEngine.Canvas CurrentСanvas { get;}

        float Height { get;}
        float Width { get; }

        float XMax { get; }
        float YMax { get; }
    }
}