using System.Collections.Generic;
using UnityEngine;

namespace Assets.src.Viewers
{
    public class MenuViewer : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _content;

        private IList<RectTransform> _items;

        private void Awake()
        {
            Debug.Assert(_content is null);

            _items = new List<RectTransform>();
        }

        public void AddItem(RectTransform rect)
        {
            _items.Add(rect);
        }
    }
}
