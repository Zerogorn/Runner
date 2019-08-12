using System;
using UniRx;

namespace Assets.src.Ui.Models
{
	public class MenuModel
    {
        private readonly ReactiveCommand _star;
        private readonly ReactiveProperty<string> _startText;
        
        public MenuModel()
        {
            _star = new ReactiveCommand();
            _startText = new ReactiveProperty<string>("start");
        }

        public void StartExecute()
        {
            _star.Execute();
        }

        public void SubscribeStart(Action<Unit> action)
        {
            _star.Subscribe(action);
        }

        public void SubscribeStartText(Action<string> action)
        {
            _startText.Subscribe(action);
        }
    }
}
