using System;
using System.Collections.Generic;
using System.Linq;
using src.Ui.Layers.interfaces;
using src.Ui.Viewers.interfaces;
using UnityEngine;

namespace src.Ui.Layers
{
	public class Layer <T>: ILayer
		where T : IComponent 
	{
		public LayersTypes Type { get;}

		private readonly RectTransform _container;
		private readonly IList<KeyValuePair<string, T>> _elements;

		private Layer()
		{
			_elements = new List<KeyValuePair<string, T>>();
		}
		
		public Layer(LayersTypes type, RectTransform container)
			: this()
		{
			Type = type;
			_container = container;
		}

		public void Add(string key, T value)
		{
			_elements.Add(new KeyValuePair<string, T>(key, value));
		}
		
		public void SetEnable(string key
							  , bool active)
		{
			_elements.FirstOrDefault(x => x.Key.Equals(key)).Value.SetActive(active);
		}
	}
}
