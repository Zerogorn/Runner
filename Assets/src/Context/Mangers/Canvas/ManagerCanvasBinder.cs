using Context.Mangers.interfaces;

namespace Context.Mangers.Canvas
{
    internal sealed class ManagerCanvasBinder : IContextBinder
    {
        private readonly ManagerCanvas _managerCanvas;
        public ManagerCanvasBinder(ManagerCanvas managerCanvas)
        {
            _managerCanvas = managerCanvas;
        }

        public void Bind()
        {
            // todo;
        }
    }
}