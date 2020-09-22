using Utils.Container;

namespace Context.Mangers.Canvas
{
    internal sealed class ManagerCanvasFactory
    {
        private readonly Container<ManagerCanvas, IManagerCanvas> _managerCanvasContainer;
        private readonly ManagerCanvas _managerCanvas;
        private readonly ManagerCanvasBinder _managerCanvasBinder;

        public ManagerCanvasFactory()
        {
            _managerCanvasContainer = new Container<ManagerCanvas, IManagerCanvas>();
            _managerCanvas = new ManagerCanvas();
            _managerCanvasBinder = new ManagerCanvasBinder(_managerCanvas);
        }

        public Container<ManagerCanvas, IManagerCanvas> Create()
        {
            _managerCanvasBinder.Bind();
            _managerCanvasContainer.Swap(_managerCanvas);

            return _managerCanvasContainer;
        }
    }
}