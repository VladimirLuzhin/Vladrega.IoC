namespace Vladrega.IoC.Implementation;

/// <summary>
/// Информация о сервисе, закрыта модификтаором доступа, т.к. этот класс должен быть использован только внутри текущей сборки
/// </summary>
internal record ServiceInfo
{
    /// <summary>
    /// Базовый тип
    /// </summary>
    internal Type BaseType { get; }
    
    /// <summary>
    /// Тип реализации
    /// </summary>
    internal Type Implementation { get; }
    
    /// <summary>
    /// Жизненный цикл сервиса
    /// </summary>
    internal ServiceLifetime Lifetime { get; }

    /// <summary>
    /// .ctor
    /// </summary>
    public ServiceInfo(Type baseType, Type implementation, ServiceLifetime lifetime)
    {
        BaseType = baseType;
        Implementation = implementation;
        Lifetime = lifetime;
    }
}