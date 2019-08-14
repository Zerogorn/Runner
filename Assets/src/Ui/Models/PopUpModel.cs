using System;
using UniRx;

namespace Assets.src.Ui.Models
{
    internal sealed class PopUpModel
    {
        private const string REPEAT = "Repiat";
        private const string TO_MENU = "to Menu";
        
        private readonly ReactiveCommand _repeat;
        private readonly ReactiveProperty<string> _repeatText;

        private readonly ReactiveCommand _toMenu;
        private readonly ReactiveProperty<string> _toMenuText;

        public PopUpModel()
        {
            _repeat = new ReactiveCommand();
            _repeatText = new ReactiveProperty<string>(REPEAT);

            _toMenu = new ReactiveCommand();
            _toMenuText = new ReactiveProperty<string>(TO_MENU);
        }

        public void ExecuteRepeat()
        {
            _repeat.Execute();
        }

        public void SubscribeRepeat(Action<Unit> action)
        {
            _repeat.Subscribe(action);
        }

        public void SubscribeRepeatText(Action<string> action)
        {
            _repeatText.Subscribe(action);
        }

        public void ExecuteToMenu()
        {
            _toMenu.Execute();
        }

        public void SubscribeToMenu(Action<Unit> action)
        {
            _toMenu.Subscribe(action);
        }

        public void SubscribeToMenuText(Action<string> action)
        {
            _toMenuText.Subscribe(action);
        }
    }
}
