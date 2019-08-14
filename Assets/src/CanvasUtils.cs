using UnityEngine;

namespace src
{
	internal class CanvasUtils
	{
		public Canvas UiCanvas { get; }

		public float Height { get; }
		public float Width { get; }
		
		public float XMax { get; }
		public float YMax { get; }
		
		public CanvasUtils(Canvas uiCanvas)
		{
			UiCanvas = uiCanvas;
			
			Height = Screen.height / UiCanvas.scaleFactor;
			Width = Screen.width / UiCanvas.scaleFactor;

			XMax = Width / 2;
			YMax = Height / 2;
		}
	}
}
