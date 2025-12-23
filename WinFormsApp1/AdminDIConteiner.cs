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

            container.Register<EventDataViewModel, AddingEventViewModel>(ServiceLifetime.Scoped);
            container.Register<EventDataViewModel, EventDetailsViewModel>(ServiceLifetime.Scoped);
            container.Register<AbstractManagmentModelView, EventMenegmentModelView>(ServiceLifetime.Scoped);
            container.Register<AbstractManagmentModelView, TeacherManagementModelView>(ServiceLifetime.Scoped);
            container.Register<TeacherDataViewModel, AddingTeacherViewModel>(ServiceLifetime.Scoped);

            //container.Register<LinkingTeacherToLessonViewModel>(ServiceLifetime.Scoped);
            //container.Register<IViewForm, LindingTeacherToLessonView>(ServiceLifetime.Scoped);

            container.Register<IViewForm, AddingEventView>(ServiceLifetime.Scoped);
            container.Register<IViewForm, EventDetailsView>(ServiceLifetime.Scoped);
            container.Register<AbstractManagementView, EventManagementView>(ServiceLifetime.Scoped);
            container.Register<AbstractManagementView, TeachersManagementView>(ServiceLifetime.Scoped);
            container.Register<IViewForm, AddingTeacherView>(ServiceLifetime.Scoped);

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

