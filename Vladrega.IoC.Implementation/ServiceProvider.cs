using System.Globalization;
using System.Reflection;

namespace Vladrega.IoC.Implementation;

/// <summary>
/// Реализация сервис-провайдера по-умолчанию
/// </summary>
internal class ServiceProvider : IServiceProvider
{
    private readonly Dictionary<Type, ServiceInfo> _services;
    private readonly Dictionary<Type, object> _singletons = new();

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="services">Словарь с описанием зависимостей</param>
    public ServiceProvider(Dictionary<Type,ServiceInfo> services)
    {
        _services = services;
    }

    /// <summary>
    /// Получение инстанса сервиса указанного типа
    /// </summary>
    /// <typeparam name="T">Тип объекта</typeparam>
    public T GetService<T>()
    {
        var type = typeof(T);
        return (T) GetService(type);
    }

    /// <summary>
    /// Получение инстанса сервиса указанного типа
    /// </summary>
    /// <param name="type">Тип объекта</param>
    /// <exception cref="TypeLoadException">Выбрасывается, если не удалось создать экземпляр сервиса</exception>
    public object GetService(Type type)
    {
        if (!_services.TryGetValue(type, out var serviceInfo))
            throw new TypeLoadException($"Не удалось зарезолвить {type.FullName}");

        if (serviceInfo.Lifetime == ServiceLifetime.Singleton && _singletons.TryGetValue(type, out var instance))
            return instance;

        var constructors = serviceInfo.Implementation.GetConstructors();
        if (constructors.Length > 1)
            throw new TypeLoadException($"У типа {type.FullName} объявлено более 1 коснтруктора");

        var constructor = constructors.Single();
        var constructorParameters = constructor.GetParameters();

        return CreateInstance(serviceInfo, constructorParameters);
    }

    private object CreateInstance(ServiceInfo serviceInfo, ParameterInfo[] constructorParameters)
    {
        var parameterInstances = new List<object>();
        foreach (var parameter in constructorParameters)
        {
            parameterInstances.Add(GetService(parameter.ParameterType));
        }

        var requiredInstance = parameterInstances.Count > 0
            ? Activator.CreateInstance(serviceInfo.Implementation, BindingFlags.Instance | BindingFlags.Public, null, parameterInstances.ToArray(), CultureInfo.CurrentCulture)
            : Activator.CreateInstance(serviceInfo.Implementation);

        if (requiredInstance == null)
            throw new TypeLoadException($"Не удалось вызвать конструктор у типа {serviceInfo.BaseType.FullName}");
        
        if (serviceInfo.Lifetime == ServiceLifetime.Singleton)
            _singletons.TryAdd(serviceInfo.BaseType, requiredInstance);

        return requiredInstance;
    }
}