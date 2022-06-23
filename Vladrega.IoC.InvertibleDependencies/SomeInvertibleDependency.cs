using Vladrega.IoC.Implementation.ClassExmaples;

namespace Vladrega.IoC.InvertibleDependencies;

/// <summary>
/// Класс для демонстрации инверсии зависимостей
/// </summary>
public class SomeInvertibleDependency : IInvertibleDependency
{
    public SomeInvertibleDependency()
    {
        Console.WriteLine($"Выполнился конструктор класс {nameof(SomeInvertibleDependency)}");   
    }
    
    /// <summary>
    /// Показать текст
    /// </summary>
    public void ShowText()
    {
        Console.WriteLine("Inverted dependency");
    }
}