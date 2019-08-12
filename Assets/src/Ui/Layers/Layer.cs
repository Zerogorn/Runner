using System.Collections.Generic;
using System.Linq;
using src.Ui.Layers.interfaces;
using UnityEngine;

namespace src.Ui.Layers
{
	public class Layer <TK, TV>: ILayer
	{
		public LayersTypes Type { get;}
		
		private readonly RectTransform _container;
		private readonly IList<KeyValuePair<TK, TV>> _windows;

		private Layer()
		{
			_windows = new List<KeyValuePair<TK, TV>>();
		}
		
		public Layer(LayersTypes type, RectTransform container)
			: this()
		{
			Type = type;
			_container = container;
		}

		public void Add(TK key, TV value)
		{
			_windows.Add(new KeyValuePair<TK, TV>(key, value));
		}

		public void Show<TKey>(TKey key)
			// where TKey : TK
		{
			// _windows.FirstOrDefault(x => x.Key.Equals(key)).Value.;
		}
	}
}
