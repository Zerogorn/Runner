using UnityEngine.Assertions;
using Utils.Container.interfaces;

namespace Utils.Container
{
    public sealed class Container<TType, TTypeInterface> : IContextContainer<TType, TTypeInterface>
        where TType : TTypeInterface
    {
        private TTypeInterface _instance;

        public TTypeInterface Instance()
        {
            return _instance;
        }

        public void Swap(TType newInstance)
        {
            Assert.IsTrue(_instance == null, $"{nameof(TType) == null}");

            _instance = newInstance;
        }
    }
}