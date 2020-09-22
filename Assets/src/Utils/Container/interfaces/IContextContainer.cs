namespace Utils.Container.interfaces
{
    public interface IContextContainer<in TType, out TTypeInterface>
        where TType : TTypeInterface
    {
        TTypeInterface Instance();
    }
}