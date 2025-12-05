using DataAccess.Postgres;
using DataAccess.Postgres.Repository;
using Logica.DI;
using WinFormsApp1.View;
using WinFormsApp1.View.Event;
using WinFormsApp1.ViewModel.Event;

namespace WinFormsApp1
{
    internal static class AdminConteiner
    {
        private static Container container;

        public static Container Container => container ??= ConfigurationContainer();

        private static Container ConfigurationContainer()
        {
            var container = new Container();

            var db = new ApplicationDbContext();
            container.RegisterSingleton(db);

            container.Register<EventRepository>(ServiceLifetime.Singleton);

            container.Register<AddEventViewModel>(ServiceLifetime.Scoped);
            container.Register<EventDetailsViewModel>(ServiceLifetime.Scoped);
            container.Register<EventMenegmentModelView>(ServiceLifetime.Scoped);

            container.Register<AddEventView>(ServiceLifetime.Scoped);
            container.Register<EventDetailsView>(ServiceLifetime.Scoped);
            container.Register<EventManagementView>(ServiceLifetime.Scoped);

            container.Register<AdminMainView>(ServiceLifetime.Singleton);
            container.Register<AdminMainViewModel>(ServiceLifetime.Singleton);

            return container;
        }

        public static T GetService<T>() where T : class
        {
            return Container.GetService<T>();
        }
        
        public static T GetService<T>(params object[] parametrs) where T : class
        {
            return Container.GetService<T>(parametrs);
        }

        public static object GetService(Type serviceType)
        {
            return Container.GetService(serviceType);
        }
    }
}

