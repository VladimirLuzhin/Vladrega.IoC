namespace Vladrega.IoC.Implementation.ClassExmaples;

/// <summary>
/// Пример класс с использование жизненного цикла Transient.
/// </summary>
public class TransientExample
{
    /// <summary>
    /// Делаем статичное поле привязанное к типу, для того, чтобы каждый новый инстанс содержал новое значение этого поля
    /// </summary>
    private static int _counter;

    private readonly int _instanceCounter;
    
    /// <summary>
    /// .ctor
    /// </summary>
    public TransientExample()
    {
        _instanceCounter = _counter++;
        Console.WriteLine($"Выполнился конструктор класс {nameof(TransientExample)}");
    }
    
    /// <summary>
    /// Показать значение каунтера
    /// </summary>
    public void ShowCounter()
    {
        Console.WriteLine($"Для текущего инстанса класса значение каунтера = {_instanceCounter}");
    }
}