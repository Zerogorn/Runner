using System.Collections.Generic;
using System.Runtime.CompilerServices;
using src.Ui.interfaces;
using src.Ui.Layers.interfaces;
using src.Ui.Viewers.Windows.interfaces;
using UnityEngine;

namespace src.Ui.Layers
{
	public class Layer<T> : ILayer
	{
		public const string LAYER = "window";
		
		private RectTransform _container;
		private readonly IList<T> _windows;

		private Layer()
		{
			_windows = new List<T>();
		}
		
		public Layer(RectTransform container)
			: this()
		{
			
			_container = container;
		}

		public void Add(T window)
		{
			_windows.Add(window);
		}	
	}
}
