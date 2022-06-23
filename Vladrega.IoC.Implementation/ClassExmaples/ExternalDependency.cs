namespace Vladrega.IoC.Implementation.ClassExmaples;

/// <summary>
/// Внешняя зависимость, в которую прокидывается инвертируемая зависимость
/// </summary>
public class ExternalDependency
{
    private readonly IInvertibleDependency _invertibleDependency;

    /// <summary>
    /// .ctor
    /// </summary>
    public ExternalDependency(IInvertibleDependency invertibleDependency)
    {
        _invertibleDependency = invertibleDependency;
        Console.WriteLine($"Выполнился конструктор класс {nameof(ExternalDependency)}");
    }

    /// <summary>
    /// Вывод текста
    /// </summary>
    public void ShowText()
    {
        _invertibleDependency.ShowText();
    }
}