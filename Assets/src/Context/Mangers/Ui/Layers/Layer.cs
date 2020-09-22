using System.Collections.Generic;
using System.Linq;
using Ui.Components.interfaces;
using Ui.Utils;

namespace Context.Mangers.Ui.Layers
{
    internal sealed class Layer<T> : ILayer
        where T : IComponent
    {
        public LayersTypes Type { get; }

        private readonly IList<KeyValuePair<string, T>> _elements;
        private IComponent _active;

        private Layer()
        {
            _elements = new List<KeyValuePair<string, T>>();
        }

        public Layer(LayersTypes type)
            : this()
        {
            Type = type;
        }

        public void Add(string key,
                        T value)
        {
            _elements.Add(new KeyValuePair<string, T>(key, value));
        }

        public void HideOpen()
        {
            _active.SetActive(false);
        }

        public void SetEnable(string key,
                              bool active)
        {
            _active?.SetActive(false);

            _active = _elements.FirstOrDefault(x => x.Key.Equals(key))
                            .Value;

            _active.SetActive(active);
        }
    }
}
