using System.Collections.Generic;
using src.Ui.Viewers.interfaces;
using TMPro;
using UnityEngine;

namespace src.Ui.Mvc.Popups
{
    public class PopUpViewer : MonoBehaviour, IPopUp
    {        
        [SerializeField]
        private TextMeshProUGUI _description;

        [SerializeField]
        private RectTransform _container;

        private List<RectTransform> _items;

        private void Awake()
        {
            Debug.Assert(_description != null);
            Debug.Assert(_container != null);

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

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
