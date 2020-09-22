using Ui.Utils;

namespace Context.Mangers.Ui.Layers
{
    internal interface ILayer
    {
        LayersTypes Type { get; }

        void HideOpen();

        void SetEnable(string key,
                       bool active);
    }
}
