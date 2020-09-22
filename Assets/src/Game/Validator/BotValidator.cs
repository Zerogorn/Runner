using System;
using Game.Validator.interfaces;
using UniRx;

namespace Game.Validator
{
    internal sealed class BotValidator : IBotValidator
    {
        private readonly int _time = 1;
        private readonly ReactiveCommand _resetCmd;

        private IDisposable _disposable;

        public BotValidator()
        {
            _resetCmd = new ReactiveCommand();
        }

        public void Start()
        {
            _disposable = Observable.Timer(TimeSpan.FromSeconds(_time))
                                    .Repeat()
                                    .Subscribe(_ => ResetBot());
        }

        public void Stop()
        {
            _disposable?.Dispose();
        }

        private void ResetBot()
        {
            _resetCmd.Execute();
        }

        public IDisposable Subscribe(Action<Unit> action)
        {
            return _resetCmd.Subscribe(action);
        }
    }
}
