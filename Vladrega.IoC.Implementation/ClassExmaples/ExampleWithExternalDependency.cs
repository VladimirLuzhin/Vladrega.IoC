namespace Vladrega.IoC.Implementation.ClassExmaples;

/// <summary>
/// Пример для демонстрации прокидывания внешней зависимости, зарегистрированной в <see cref="ServiceCollection"/>
/// </summary>
public class ExampleWithExternalDependency
{
    private readonly ExternalDependency _externalDependency;

    /// <summary>
    /// .ctor
    /// </summary>
    public ExampleWithExternalDependency(ExternalDependency externalDependency)
    {
        _externalDependency = externalDependency;
        Console.WriteLine($"Выполнился конструктор класс {nameof(ExampleWithExternalDependency)}");
    }

    /// <summary>
    /// Вывод текста
    /// </summary>
    public void ShowText()
    {
        Console.Write($"Выполнение метода {nameof(ShowText)} класса {nameof(ExampleWithExternalDependency)}: ");
        _externalDependency.ShowText();
    }
}