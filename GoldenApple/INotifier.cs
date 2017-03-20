namespace GoldenApple
{
    public interface INotifier<T>
    {
        bool notify(T data);
    }
}
