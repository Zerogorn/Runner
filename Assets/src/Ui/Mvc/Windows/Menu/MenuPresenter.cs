using src.Ui.Models;
using UniRx;

namespace src.Ui.Mvc.Windows.Menu
{
    public class MenuPresenter 
    {
        private readonly MenuViewer _menuViewer;
        private readonly MenuModel _menuModel;
        
        public MenuPresenter(MenuViewer menuViewer, MenuModel menuModel)
        {
            _menuViewer = menuViewer;
            _menuModel = menuModel;

            Binding();
        }

        private void Binding()
        {
            _menuModel.ButtonDefault
                      .ObserveAdd()
                      .Subscribe(x => _menuViewer.AddItem(x.Value.transform));
            
            _menuModel.ButtonDefault
                      .ObserveRemove()
                      .Subscribe(x => _menuViewer.RemoveItem(x.Value.transform));
        }
    }
}
