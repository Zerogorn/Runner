using System;
using UniRx;

namespace Assets.src.Ui.Models
{
    internal sealed class PopUpModel
    {
        private const string REPEAT = "Repat";
        private const string TO_MENU = "To Menu";
        private const string GAME_OVER = "Game Over";

        private readonly ReactiveProperty<string> _description;

        private readonly ReactiveCommand _repeat;
        private readonly ReactiveProperty<string> _repeatText;

        private readonly ReactiveCommand _toMenu;
        private readonly ReactiveProperty<string> _toMenuText;

        public PopUpModel()
        {
            _description = new ReactiveProperty<string>(GAME_OVER);

            _repeat = new ReactiveCommand();
            _repeatText = new ReactiveProperty<string>(REPEAT);

            _toMenu = new ReactiveCommand();
            _toMenuText = new ReactiveProperty<string>(TO_MENU);
        }

        public void SubscribeDescription(Action<string> action)
        {
            _description.Subscribe(action);
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
