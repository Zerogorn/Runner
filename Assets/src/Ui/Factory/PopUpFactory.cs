using src.ScrObj.Ui;
using src.ScrObj.Ui.interfaces;
using src.Ui.Models;
using src.Ui.Mvc.Popups;
using UnityEngine;

namespace src.Ui.Factory
{
    public class PopUpFactory
    {
        private readonly IUiPrefabs _uiPrefabs;
        private readonly ModelContext _modelContext;

        public PopUpFactory(IUiPrefabs uiPrefabs, ModelContext modelContext)
        {
            _uiPrefabs = uiPrefabs;
            _modelContext = modelContext;
        }

        public PopUpViewer PopUp(Transform parent)
        {
            PopUpViewer popUpViewer = _uiPrefabs.Popup(parent);
            PopUpModel popUpModel = _modelContext.PopUpModel;
            
            PopUpPresenter presenter = new PopUpPresenter(popUpViewer, popUpModel);
            
            return popUpViewer;
        }
    }
}
