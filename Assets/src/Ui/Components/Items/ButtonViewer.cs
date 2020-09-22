using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Components.Items
{
    internal sealed class ButtonViewer : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private TextMeshProUGUI _text;

        private void Awake()
        {
            Debug.Assert(_button != null);
            Debug.Assert(_text != null);
        }

        public IDisposable SetListener(Action<Unit> action)
        {
            return _button.OnClickAsObservable()
                          .Subscribe(action,
                                     Debug.LogError)
                          .AddTo(this);
        }

        public void SetText(string text)
        {
            _text.SetText(text);
        }
    }
}
