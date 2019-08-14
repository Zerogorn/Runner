using Assets.src.ScrObj.Ui.interfaces;
using src.Ui.Components.interfaces;
using src.Ui.Components.Items;
using TMPro;
using UnityEngine;

namespace src.Ui.Components.Popups
{
    public class PopUpViewer : MonoBehaviour, IPopUp
    {        
        [SerializeField]
        private TextMeshProUGUI _description;

        [SerializeField]
        private RectTransform _container;

        public ButtonViewer Repeat { get; private set; }
        public ButtonViewer ToMenu { get; private set; }

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
