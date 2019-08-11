using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Assets.src.Viewers
{
    public class ButtonDefaultViewer : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private TextMeshProUGUI _text;

        private void Awake()
        {
            Debug.Assert(_button is null);
            Debug.Assert(_text is null);
        }

        public IDisposable SetListener(Action<Unit> action)
        {
            return _button?.OnClickAsObservable()
                          .Subscribe(action,
                                     Debug.LogError)
                          .AddTo(this);
        }

        public void SetText(string text)
        {
            _text?.SetText(text);
        }
    }
}
