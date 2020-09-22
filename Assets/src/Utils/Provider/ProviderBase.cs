using System;

namespace Utils.Provider
{
    public abstract class ProviderBase<TType, TTypeInterface>
        where TType : TTypeInterface
    {
        private static TTypeInterface _instance;

        public static TTypeInterface Get()
        {
            if (_instance == null)
            {
                _instance = Activator.CreateInstance<TType>();
            }

            return _instance;
        }

        public static void Set(TTypeInterface newInstance)
        {
            _instance = newInstance;
        }
    }
}