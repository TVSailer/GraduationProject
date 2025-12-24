using Admin.View;
using Admin.View.Teachers;
using Admin.ViewModel;
using Admin.ViewModel.Teachers;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.DI;
using WinFormsApp1.View;
using WinFormsApp1.View.Event;
using WinFormsApp1.View.Teachers;
using WinFormsApp1.ViewModel.Event;

namespace WinFormsApp1
{
    internal static class AdminDIConteiner
    {
        private static DIContainer container;

        public static DIContainer Container => container ??= ConfigurationContainer();

        private static DIContainer ConfigurationContainer()
        {
            var container = new DIContainer();

            var db = new ApplicationDbContext();
            container.RegisterSingleton(db);

            container.Register<EventRepository>(ServiceLifetime.Singleton);
            container.Register<TeacherRepository>(ServiceLifetime.Singleton);
            container.Register<LessonsRepository>(ServiceLifetime.Singleton);

            container.Register<AddingEventViewModel>(ServiceLifetime.Scoped);
            container.Register<EventDetailsViewModel>(ServiceLifetime.Scoped);
            container.Register<EventMenegmentModelView>(ServiceLifetime.Scoped);
            container.Register<TeacherManagementModelView>(ServiceLifetime.Scoped);
            container.Register<AddingTeacherViewModel>(ServiceLifetime.Scoped);

            //container.Register<LinkingTeacherToLessonViewModel>(ServiceLifetime.Scoped);
            //container.Register<IViewForm, LindingTeacherToLessonView>(ServiceLifetime.Scoped);

            container.Register<AddingEventView>(ServiceLifetime.Scoped);
            container.Register<EventDetailsView>(ServiceLifetime.Scoped);
            container.Register<EventManagementView>(ServiceLifetime.Scoped);
            container.Register<TeachersManagementView>(ServiceLifetime.Scoped);
            container.Register<AddingTeacherView>(ServiceLifetime.Scoped);

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

