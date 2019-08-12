using UnityEditor;

namespace src.Ui.Layers.interfaces
{
	public interface ILayer
	{
		LayersTypes Type { get; }
		
		void Show<TKey>(TKey key);
	}
}
