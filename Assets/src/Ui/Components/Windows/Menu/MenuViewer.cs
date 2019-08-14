using Assets.src.ScrObj.Ui.interfaces;
using src.Ui.Components.interfaces;
using src.Ui.Components.Items;
using UnityEngine;

namespace src.Ui.Components.Windows.Menu
{
    internal sealed class MenuViewer : MonoBehaviour, IWindow
    {        
        [SerializeField]
        private RectTransform _content;

        public ButtonViewer ButtonStart { get; private set; }

        private void Awake()
        {
            Debug.Assert(_content != null);
        }

        public void Initialization(IUiPrefabs prefabs)
        {
            ButtonStart = prefabs.ButtonDefault(_content);
            ButtonStart.gameObject.SetActive(true);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
