using Ui.Models;

namespace Ui.Components.Popups
{
    internal sealed class PopUpPresenter
    {
        private readonly PopUpViewer _popUpViewer;
        private readonly PopUpModel _popUpModel;

        public PopUpPresenter(PopUpViewer popUpViewer
                              , PopUpModel popUpModel)
        {
            _popUpViewer = popUpViewer;
            _popUpModel = popUpModel;

            Binding();
        }

        private void Binding()
        {
            _popUpViewer.Repeat.SetListener(_ => _popUpModel.ExecuteRepeat());
            _popUpModel.SubscribeRepeatText(_popUpViewer.Repeat.SetText);

            _popUpViewer.ToMenu.SetListener(_ => _popUpModel.ExecuteToMenu());
            _popUpModel.SubscribeToMenuText(_popUpViewer.ToMenu.SetText);

            _popUpModel.SubscribeDescription(_popUpViewer.SetDescription);
        }
    }
}
