using Assets.src.ScrObj.Ui.interfaces;
using Assets.src.Ui.Models;
using src.Ui.Components.Popups;
using UnityEngine;

namespace Assets.src.Ui.Factory
{
    internal sealed class PopUpFactory
    {
        private readonly IUiPrefabs _uiPrefabs;
        private readonly ModelContext _modelContext;

        public PopUpFactory(IUiPrefabs uiPrefabs
                            , ModelContext modelContext)
        {
            _uiPrefabs = uiPrefabs;
            _modelContext = modelContext;
        }

        public PopUpViewer PopUp(Transform parent)
        {
            PopUpViewer popUpViewer = _uiPrefabs.Popup(parent);
            popUpViewer.Initialization(_uiPrefabs);
            PopUpModel popUpModel = _modelContext.PopUpModel;

            PopUpPresenter presenter = new PopUpPresenter(popUpViewer, popUpModel);

            return popUpViewer;
        }
    }
}
