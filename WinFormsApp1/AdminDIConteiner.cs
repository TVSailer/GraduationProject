using Admin.View;
using Admin.View.Moduls.Event;
using Admin.View.Moduls.Lesson;
using Admin.View.Moduls.Teacher;
using Admin.ViewModel;
using Admin.ViewModel.Lesson;
using Admin.ViewModel.Teachers;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.DI;
using WinFormsApp1.View;
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

            container.Register<LessonsRepository>(ServiceLifetime.Singleton);
            container.Register<TeacherRepository>(ServiceLifetime.Singleton);
            container.Register<EventRepository>(ServiceLifetime.Singleton);
            container.Register<NewsRepository>(ServiceLifetime.Singleton);

            container.Register<EventAddingViewModel>(ServiceLifetime.Scoped);
            container.Register<EventDetailsViewModel>(ServiceLifetime.Scoped);
            container.Register<EventMenegmentModelView>(ServiceLifetime.Scoped);
            container.Register<TeacherManagementModelView>(ServiceLifetime.Scoped);
            container.Register<TeacherAddingViewModel>(ServiceLifetime.Scoped);
            container.Register<LessonAddingViewModel>(ServiceLifetime.Scoped);
            container.Register<LessonDetailsViewModel>(ServiceLifetime.Scoped);
            container.Register<LessonManagmentViewModel>(ServiceLifetime.Scoped);

            container.Register<EventAddingView>(ServiceLifetime.Scoped);
            container.Register<EventDetailsView>(ServiceLifetime.Scoped);
            container.Register<EventManagementView>(ServiceLifetime.Scoped);
            container.Register<TeacherManagementView>(ServiceLifetime.Scoped);
            container.Register<TeacherAddingView>(ServiceLifetime.Scoped);
            container.Register<LessonDetailsView>(ServiceLifetime.Scoped);
            container.Register<LessonAddingView>(ServiceLifetime.Scoped);
            container.Register<LessonManagementView>(ServiceLifetime.Scoped);

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

