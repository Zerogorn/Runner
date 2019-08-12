using System.Collections.Generic;
using src.Ui.Viewers.interfaces;
using UnityEngine;

namespace src.Ui.Mvc.Windows.Menu
{
    public class MenuViewer : MonoBehaviour, IWindow
    {        
        [SerializeField]
        private RectTransform _content;
        
        private IList<Transform> _items;

        private void Awake()
        {
            Debug.Assert(_content != null);

            _items = new List<Transform>();
        }

        public void AddItem(Transform rect)
        {
            _items.Add(rect);
        }
        
        public void RemoveItem(Transform rect)
        {
            _items.Add(rect);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
