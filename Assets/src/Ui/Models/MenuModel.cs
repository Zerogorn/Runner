using System.Collections.Generic;
using src.Ui.Mvc.Items;
using UniRx;

namespace src.Ui.Models
{
	public class MenuModel
	{
		public readonly IReactiveCollection<ButtonDefaultViewer> ButtonDefault;

		public MenuModel()
		{
			ButtonDefault = new ReactiveCollection<ButtonDefaultViewer>();
		}

		public void Buttons(IEnumerable<ButtonDefaultViewer> buttons)
		{
			IEnumerator<ButtonDefaultViewer> enumerator = buttons.GetEnumerator();
			
			while (enumerator.MoveNext())
			{
				ButtonDefaultViewer buttonDefaultViewer = enumerator.Current;
				ButtonDefault.Add(buttonDefaultViewer);
			}
			
			enumerator.Dispose();

		}
	}
}
