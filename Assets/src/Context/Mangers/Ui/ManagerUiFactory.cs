using Utils.Container;

namespace Context.Mangers.Ui
{
    internal sealed class ManagerUiFactory
    {
        private readonly Container<ManagerUi, IManagerUi> _mangerUiContainer;
        private readonly ManagerUi _managerUi;
        private readonly ManagerUiBinder _managerUiBinder;

        public ManagerUiFactory()
        {
            _mangerUiContainer = new Container<ManagerUi, IManagerUi>();
            _managerUi = new ManagerUi();
            _managerUiBinder = new ManagerUiBinder(_managerUi);
        }

        public Container<ManagerUi, IManagerUi> Create()
        {
            _managerUiBinder.Bind();
            _mangerUiContainer.Swap(_managerUi);

            return _mangerUiContainer;
        }
    }
}