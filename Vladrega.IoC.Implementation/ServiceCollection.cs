namespace Vladrega.IoC.Implementation;

/// <summary>
/// Класс-колекция для хранения информации о регистрируемых сервисах
/// </summary>
public class ServiceCollection
{
    private readonly Dictionary<Type, ServiceInfo> _services = new();

    /// <summary>
    /// Добавить сервис с жизненным циклом Singletone (одиночка)
    /// </summary>
    /// <typeparam name="T">Тип сервиса</typeparam>
    public void AddSingleton<T>()
    {
        var type = typeof(T);
        AddSingleton(type, type);
    }

    /// <summary>
    /// Добавить сервис с жизненным циклом Singletone (одиночка)
    /// </summary>
    /// <typeparam name="TBaseType">Базовый тип (абстракция)</typeparam>
    /// <typeparam name="TImpl">Тип реализации</typeparam>
    public void AddSingleton<TBaseType, TImpl>() where TImpl: TBaseType
    {
        var baseType = typeof(TBaseType);
        var implementationType = typeof(TImpl);
        
        AddSingleton(baseType, implementationType);
    }

    /// <summary>
    /// Добавить сервис с жизненным циклом Transient (новйы инстанс на каждое получение)
    /// </summary>
    /// <typeparam name="T">Тип сервиса</typeparam>
    public void AddTransient<T>()
    {
        var type = typeof(T);
        AddTransient(type, type);
    }

    /// <summary>
    /// Добавить сервис с жизненным циклом Transient (новйы инстанс на каждое получение)
    /// </summary>
    /// <typeparam name="TBaseType">Базовый тип (абстракция)</typeparam>
    /// <typeparam name="TImpl">Тип реализации</typeparam>
    public void AddTransient<TBaseType, TImpl>() where TImpl: TBaseType 
    {
        var baseType = typeof(TBaseType);
        var implementationType = typeof(TImpl);
        
        AddTransient(baseType, implementationType);
    }

    /// <summary>
    /// Собрать <see cref="IServiceProvider"/>
    /// </summary>
    public IServiceProvider Build()
    {
        return new ServiceProvider(_services);
    }

    private void AddTransient(Type type, Type implementation) =>
        AddService(type, implementation, ServiceLifetime.Transient);
    
    private void AddSingleton(Type type, Type implementation) => 
        AddService(type, implementation, ServiceLifetime.Singleton);

    private void AddService(Type type, Type implementation, ServiceLifetime lifetime) =>
        _services.TryAdd(type, new ServiceInfo(type, implementation, lifetime));
}