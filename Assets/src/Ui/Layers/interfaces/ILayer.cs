using Assets.src.Ui.Utils;

namespace Assets.src.Ui.Layers.interfaces
{
	internal interface ILayer
	{
		LayersTypes Type { get; }

		void HideOpen();

		void SetEnable(string key
					   , bool active);
	}
}
