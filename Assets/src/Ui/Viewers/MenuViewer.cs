using System.Collections.Generic;
using src.Ui.interfaces;
using UnityEngine;

namespace src.Ui.Viewers
{
    public class MenuViewer : MonoBehaviour, IWindow
    {
        [SerializeField]
        private RectTransform _content;

        private IList<RectTransform> _items;

        private void Awake()
        {
            Debug.Assert(_content != null);

            _items = new List<RectTransform>();
        }

        public void AddItem(RectTransform rect)
        {
            _items.Add(rect);
        }

        public void SetEnable(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
