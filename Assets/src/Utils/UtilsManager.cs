using UnityEngine;

namespace Assets.src.Utils
{
    internal sealed class UtilsManager
    {
        public CanvasUtils CanvasUtils { get; private set; }

        public UtilsManager(Canvas canvas)
        {
            CanvasUtils = new CanvasUtils(canvas);
        }

        public void Initialization()
        {
            CanvasUtils.Initialization();
        }
    }
}