using UnityEngine;

namespace Assets.src
{
    internal sealed class CanvasUtils
    {
        public Canvas UiCanvas { get; }

        public float Height { get; private set; }
        public float Width { get; private set; }

        public float XMax { get; private set; }
        public float YMax { get; private set; }

        public CanvasUtils(Canvas uiCanvas)
        {
            UiCanvas = uiCanvas;
        }

        public void Initialization()
        {
            Height = Screen.height / UiCanvas.scaleFactor;
            Width = Screen.width / UiCanvas.scaleFactor;

            XMax = Width * 0.5f;
            YMax = Height * 0.5f;
        }
    }
}
