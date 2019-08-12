using System.Collections.Generic;
using src.ScrObj.Ui.interfaces;
using src.Ui.interfaces;
using src.Ui.Layers;
using src.Ui.Layers.interfaces;
using src.Ui.Viewers.Windows.interfaces;
using UnityEngine;

namespace src.Ui
{
    public class UiManger
    {
        private Canvas _canvas;

        private readonly IList<ILayer> _layers;

        private UiManger()
        {
            _layers = new List<ILayer>();
        }
        
        public UiManger(Canvas canvas, LayerFactory layerFactory)
            : this()
        {
            Canvas(canvas);
            
            layerFactory.GetWindows(canvas.transform);
            layerFactory.GetPopup(canvas.transform);
        }
        
        private void Canvas(Canvas canvas)
        {
            _canvas = canvas;
            _canvas.worldCamera = Camera.main;
        }

        public void ShowWindow(WindowTypes types)
        {

        }
        
        public void ShowPopup(PopUpTypes types)
        {
            
        }
    }
}
