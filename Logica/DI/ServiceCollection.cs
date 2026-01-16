namespace Logica.DI
{
    public class ServiceCollection
    {
        public Dictionary<Type, ServiceDescriptor> Descriptors { get; private set; } = new();

        public void Register<TService, TImplementation>(ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            where TService : class
            where TImplementation : class, TService
        {
            Descriptors[typeof(TService)] = new ServiceDescriptor(
                typeof(TService),
                typeof(TImplementation),
                serviceLifetime);
        }

        public void Register<TService>(ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            where TService : class
            => Register<TService, TService>(serviceLifetime);

        public void RegisterScope<TService>()
            where TService : class
            => Register<TService, TService>(ServiceLifetime.Scoped);

        public void RegisterSingleton<TService>(TService instance)
            where TService : class
            => Register<TService, TService>(ServiceLifetime.Singleton);

        public void RegisterSingleton<TService>()
            where TService : class
            => Register<TService, TService>(ServiceLifetime.Singleton);
    }
}
