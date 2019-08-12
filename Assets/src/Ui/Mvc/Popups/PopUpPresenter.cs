using src.Ui.Models;

namespace src.Ui.Mvc.Popups
{
	public class PopUpPresenter
	{
		private readonly PopUpViewer _popUpViewer;
		private readonly PopUpModel _popUpModel;

		public PopUpPresenter(PopUpViewer popUpViewer
							  , PopUpModel popUpModel)
		{
			_popUpViewer = popUpViewer;
			_popUpModel = popUpModel;
		}
	}
}
