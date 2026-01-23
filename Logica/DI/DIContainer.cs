namespace Logica.DI
{
    public class DIContainer : IDisposable
    {
        public readonly Dictionary<Type, ServiceDescriptor> Description;
        private Dictionary<Type, object> scopedInstances = new();
        private bool isScope;

        public DIContainer(Dictionary<Type, ServiceDescriptor> descriptors, bool isScope)
        {
            Description = descriptors;
            this.isScope = isScope;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
        
        public object GetService(Type serviceType)
        {
            if (Description.TryGetValue(serviceType, out var descriptor)) return GetServiceInstance(descriptor);
            return serviceType is { IsAbstract: false, IsInterface: false } ? CreateInstance(serviceType) : throw new InvalidOperationException($"Сервис {serviceType.Name} не зарегистрирован");
        }
        
        public object GetServiceInstance(ServiceDescriptor serviceDescriptor)
        {
            switch (serviceDescriptor.ServiceLifetime)
            {
                case ServiceLifetime.Singleton:
                    serviceDescriptor.Instance ??= CreateInstance(serviceDescriptor.ImplementationType);
                    return serviceDescriptor.Instance;

                case ServiceLifetime.Scoped:
                    if (!isScope) return CreateInstance(serviceDescriptor.ImplementationType);
                    if (scopedInstances.TryGetValue(serviceDescriptor.ServiceType, out var instance)) return instance;
                    instance = CreateInstance(serviceDescriptor.ImplementationType);
                    scopedInstances[serviceDescriptor.ServiceType] = instance;
                    return instance;

                case ServiceLifetime.Transient:
                    return CreateInstance(serviceDescriptor.ImplementationType);

                default:
                    throw new InvalidOperationException("Неизвестный lifetime");
            }
        }

        public object CreateInstance(Type implementationType)
        {
            var containers = implementationType.GetConstructors();

            if (containers.Length == 0)
                throw new InvalidOperationException($"Нет публичных конструкторов для {implementationType.Name}");

            var container = containers
                .OrderByDescending(c => c.GetParameters().Length).First();

            var parameters = container.GetParameters();
            var parametersInstance = new object[parameters.Length];

            for (var i = 0; i < parameters.Length; i++)
                parametersInstance[i] = GetService(parameters[i].ParameterType);

            return container.Invoke(parametersInstance);
        }

        public void Dispose()
        {
            scopedInstances.Clear();
        }

    }
}
