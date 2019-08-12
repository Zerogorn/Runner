using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui.Mvc.interfaces;
using Assets.src.Ui.Mvc.Items;
using src.ScrObj.Ui.interfaces;
using UnityEngine;

namespace Assets.src.Ui.Mvc.Windows.Menu
{
    public class MenuViewer : MonoBehaviour, IWindow
    {        
        [SerializeField]
        private RectTransform _content;

        public ButtonDefaultViewer ButtonStart { get; private set; }

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
