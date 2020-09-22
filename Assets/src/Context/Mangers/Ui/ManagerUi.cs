using System.Collections.Generic;
using System.Linq;
using App;
using Context.Mangers.Canvas;
using Context.Mangers.Ui.Layers;
using Ui.Factory;
using Ui.Utils;
using Utils.Container.interfaces;

namespace Context.Mangers.Ui
{
    internal sealed class ManagerUi : IManagerUi
    {
        private readonly IList<ILayer> _layers;

        private LayerFactory _layerFactory;

        public ManagerUi()
        {
            _layers = new List<ILayer>();
        }

        private IContextContainer<ManagerCanvas, IManagerCanvas> _managerCanvas => AppManagerProvider.Get().ContextManagers.ManagerCanvas;

        public void Bind(LayerFactory layerFactory)
        {
            _layerFactory = layerFactory;
        }

        public void Initialization()
        {
            _layers.Add(_layerFactory.GetWindows(_managerCanvas.Instance().CurrentСanvas.transform));
            _layers.Add(_layerFactory.GetPopup(_managerCanvas.Instance().CurrentСanvas.transform));
        }

        public void SetActive(LayersTypes layer,
                              string key,
                              bool active)
        {
            _layers.FirstOrDefault(x => x.Type.Equals(layer))
                  ?.SetEnable(key, active);
        }

        public void HideOpenWindows()
        {
            _layers.FirstOrDefault(x => x.Type.Equals(LayersTypes.Windows))
                  ?.HideOpen();
        }

        public void HideOpenPopup()
        {
            _layers.FirstOrDefault(x => x.Type.Equals(LayersTypes.PopUp))
                  ?.HideOpen();
        }
    }
}
