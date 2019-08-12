using System.Collections.Generic;
using System.Linq;
using src.ScrObj.Ui.interfaces;
using src.Ui.Factory;
using src.Ui.Layers;
using src.Ui.Layers.interfaces;
using UnityEngine;

namespace src.Ui
{
    public class UiManger
    {
        private readonly IList<ILayer> _layers;
        
        private Canvas _canvas;
        private ModelContext _modelContext;

        private UiManger()
        {
            _layers = new List<ILayer>();
        }
        
        public UiManger(Canvas canvas, ModelContext modelContext, LayerFactory layerFactory)
            : this()
        {
            Canvas(canvas);

            _modelContext = modelContext;
            _layers.Add(layerFactory.GetWindows(canvas.transform));
            _layers.Add(layerFactory.GetPopup(canvas.transform));
        }
        
        private void Canvas(Canvas canvas)
        {
            _canvas = canvas;
            _canvas.worldCamera = Camera.main;
        }

        public void SetActive(LayersTypes layer, string key, bool active)
        {
            _layers.FirstOrDefault(x => x.Type.Equals(layer))
                  ?.SetEnable(key, active);
        }
    }
}
