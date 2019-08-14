using System.Collections.Generic;
using System.Linq;
using Assets.src.Ui.Factory;
using Assets.src.Ui.Layers.interfaces;
using Assets.src.Ui.Models;
using Assets.src.Ui.Utils;
using UnityEngine;

namespace Assets.src.Ui
{
    internal sealed class UiManger
    {
        private readonly IList<ILayer> _layers;
        
        private Canvas _canvas;

        private UiManger()
        {
            _layers = new List<ILayer>();
        }
        
        public UiManger(Canvas canvas, LayerFactory layerFactory)
            : this()
        {
            Canvas(canvas);

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
