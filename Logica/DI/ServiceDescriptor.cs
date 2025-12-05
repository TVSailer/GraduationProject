namespace Logica.DI
{
    public class ServiceDescriptor
    {
        public readonly Type ServiceType;
        public readonly Type ImplementationType;
        public readonly ServiceLifetime ServiceLifetime;
        public object Instance { get; set; }

        public ServiceDescriptor(Type service, Type implementation, ServiceLifetime serviceLifetime, object instance = null)
        {
            ServiceLifetime = serviceLifetime;
            ServiceType = service;
            ImplementationType = implementation;
            Instance = instance;
        }
    }
}
