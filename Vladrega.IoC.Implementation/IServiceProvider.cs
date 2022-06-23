namespace Vladrega.IoC.Implementation;

/// <summary>
/// Абстракция сервис-провайдера. Выделяется для абстрагированния реализации
/// </summary>
public interface IServiceProvider
{
    /// <summary>
    /// Получение сервиса по типу
    /// </summary>
    /// <typeparam name="T">Тип сервиса</typeparam>
    T GetService<T>();

    /// <summary>
    /// Получение сервиса по типу
    /// </summary>
    /// <param name="type">Тип сервиса</param>
    object GetService(Type type);
}