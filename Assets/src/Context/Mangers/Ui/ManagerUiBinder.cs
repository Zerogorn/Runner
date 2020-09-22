using Ui.Factory;

namespace Context.Mangers.Ui
{
    internal class ManagerUiBinder
    {
        private readonly ManagerUi _managerUi;

        public ManagerUiBinder(ManagerUi managerUi)
        {
            _managerUi = managerUi;
        }

        public void Bind()
        {
            var windowFactory = new WindowFactory();
            var popUpFactory = new PopUpFactory();
            var factory = new LayerFactory(windowFactory, popUpFactory);
         
            _managerUi.Bind(factory);
        }
    }
}