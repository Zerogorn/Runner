using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui.Mvc.interfaces;
using Assets.src.Ui.Mvc.Items;
using src.ScrObj.Ui.interfaces;
using TMPro;
using UnityEngine;

namespace Assets.src.Ui.Mvc.Popups
{
    public class PopUpViewer : MonoBehaviour, IPopUp
    {        
        [SerializeField]
        private TextMeshProUGUI _description;

        [SerializeField]
        private RectTransform _container;

        public ButtonDefaultViewer Repeat { get; private set; }
        public ButtonDefaultViewer ToMenu { get; private set; }

        private void Awake()
        {
            Debug.Assert(_description != null);
            Debug.Assert(_container != null);
        }

        public void Initialization(IUiPrefabs prefabs)
        {
            Repeat = prefabs.ButtonDefault(_container);
            Repeat.gameObject.SetActive(true);
            ToMenu = prefabs.ButtonDefault(_container);
            ToMenu.gameObject.SetActive(true);
        }

        public void SetDescription(string text)
        {
            _description.SetText(text);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
