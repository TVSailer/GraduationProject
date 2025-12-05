namespace Logica.DI
{
    public class ContainerScoped : IDisposable
    {
        private Container container;
        private Dictionary<Type, object> scopedInstances = new();

        public ContainerScoped(Container container)
        {
            this.container = container;
        }

        public T GetService<T>(params object[] parametrs)
        {
            return (T)GetService(typeof(T), parametrs);
        }

        public object GetService(Type serviceType, params object[] parametrs)
        {
            if (!container.descriptors.TryGetValue(serviceType, out var descriptor))
            {
                if (!serviceType.IsAbstract && !serviceType.IsInterface)
                {
                    return CreateInstance(serviceType, parametrs);
                }

                throw new InvalidOperationException($"Сервис {serviceType.Name} не зарегистрирован");
            }

            return GetServiceInstance(descriptor, parametrs);
        }

        private object GetServiceInstance(ServiceDescriptor descriptor, params object[] parametrs)
        {
            switch (descriptor.ServiceLifetime)
            {
                case ServiceLifetime.Singleton:
                    return container.GetServiceInstance(descriptor, parametrs);

                case ServiceLifetime.Scoped:
                    if (!scopedInstances.TryGetValue(descriptor.ServiceType, out var instance))
                    {
                        instance = CreateInstance(descriptor.ImplementationType, parametrs);
                        scopedInstances[descriptor.ServiceType] = instance;
                    }
                    return instance;

                case ServiceLifetime.Transient:
                    return CreateInstance(descriptor.ImplementationType, parametrs);

                default:
                    throw new InvalidOperationException("Неизвестный lifetime");
            }
        }

        private object CreateInstance(Type implementationType, params object[] parametrsUp)
        {
            var constructors = implementationType.GetConstructors();
            if (constructors.Length == 0)
                throw new InvalidOperationException($"Нет публичных конструкторов для {implementationType.Name}");

            var constructor = constructors
                .OrderByDescending(c => c.GetParameters().Length)
                .First();

            var parameters = constructor.GetParameters();
            var parameterInstances = new object[parameters.Length];

            for (int i = 0; i < parameters.Length - parametrsUp.Length; i++)
                parameterInstances[i] = GetService(parameters[i].ParameterType);

            if (parametrsUp != null)
                for (int i = parameters.Length - parametrsUp.Length; i < parameters.Length; i++)
                    parameterInstances[i] = parametrsUp[i - (parameters.Length - parametrsUp.Length)];

            return constructor.Invoke(parameterInstances);
        }

        public void Dispose()
        {
            scopedInstances.Clear();
        }
    }
}
