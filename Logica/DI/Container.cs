namespace Logica.DI
{
    public class Container
    {
        public Dictionary<Type, ServiceDescriptor> descriptors { get; private set; } = new();

        public void Register<TService, TImplementation>(ServiceLifetime serviceLifetime) 
            where TService : class
            where TImplementation : class, TService
        {
            descriptors[typeof(TService)] = new ServiceDescriptor(typeof(TService), typeof(TImplementation), serviceLifetime);
        }
        
        public void Register<TImplementation>(ServiceLifetime serviceLifetime) 
            where TImplementation : class
        {
            descriptors[typeof(TImplementation)] = new ServiceDescriptor(typeof(TImplementation), typeof(TImplementation), serviceLifetime);
        }

        public void RegisterSingleton<TService>(TService instance)
            where TService : class
        {
            descriptors[typeof(TService)] = new ServiceDescriptor(
                typeof(TService),
                instance.GetType(),
                ServiceLifetime.Singleton,
                instance);
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
        
        public T GetService<T>(params object[] parametrs)
        {
            return (T)GetService(typeof(T), parametrs);
        }

        public object GetService(Type serviceType)
        {
            if (descriptors.TryGetValue(serviceType, out var descriptor))
                return GetServiceInstance(descriptor);

            throw new InvalidOperationException($"Сервис {serviceType.Name} не зарегистрирован");
        }
        
        public object GetService(Type serviceType, object[] parametrs)
        {
            if (descriptors.TryGetValue(serviceType, out var descriptor))
                return GetServiceInstance(descriptor, parametrs);

            throw new InvalidOperationException($"Сервис {serviceType.Name} не зарегистрирован");
        }

        public object GetServiceInstance(ServiceDescriptor serviceDescriptor, params object[] parametrs)
        {
            if (serviceDescriptor.ServiceLifetime == ServiceLifetime.Singleton)
            {
                if (serviceDescriptor.Instance == null)
                    serviceDescriptor.Instance = CreateInstance(serviceDescriptor.ImplementationType, parametrs);
                return serviceDescriptor.Instance;
            }

            return CreateInstance(serviceDescriptor.ImplementationType, parametrs);
        }

        private object CreateInstance(Type implementationType, object[] parametrsUp)
        {
            var containers = implementationType.GetConstructors();

            if (containers.Length == 0)
                throw new InvalidOperationException($"Нет публичных конструкторов для {implementationType.Name}");

            var container = containers
                .OrderByDescending(c => c.GetParameters().Length).First();

            var parameters = container.GetParameters();
            var parametersInstance = new object[parameters.Length];

            for (int i = 0; i < parameters.Length - parametrsUp.Length; i++)
                parametersInstance[i] = GetService(parameters[i].ParameterType);

            if (parametrsUp != null)
                for (int i = parameters.Length - parametrsUp.Length; i < parameters.Length; i++)
                    parametersInstance[i] = parametrsUp[i - (parameters.Length - parametrsUp.Length)];

            return container.Invoke(parametersInstance);
        }
    }
}
