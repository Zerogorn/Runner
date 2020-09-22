using Context.Mangers.interfaces;
using Ui.Utils;

namespace Context.Mangers.Ui
{
    internal interface IManagerUi : IContextManager
    {
        void SetActive(LayersTypes layer, 
                       string key, 
                       bool active);
        void HideOpenWindows();
        void HideOpenPopup();
    }
}