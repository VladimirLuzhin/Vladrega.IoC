namespace Vladrega.IoC.Implementation;

/// <summary>
/// Жизненный цикл сервиса
/// </summary>
internal enum ServiceLifetime
{
    /// <summary>
    /// Одиночка
    /// </summary>
    Singleton,
    
    /// <summary>
    /// Новый инстанс на каждый запрос
    /// </summary>
    Transient
}