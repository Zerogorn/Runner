using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.src.Viewers
{
    public class PopUpViewer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _description;

        [SerializeField]
        private RectTransform _container;

        private List<RectTransform> _items;

        private void Awake()
        {
            Debug.Assert(_description is  null);
            Debug.Assert(_container is null);

            _items = new List<RectTransform>();
        }

        public void SetText(string text)
        {
            _description.SetText(text);
        }

        public void AddItemToContainer(RectTransform rect)
        {
            rect.SetParent(_container);
            rect.localScale = Vector3.one;

            _items.Add(rect);
        }
    }
}
