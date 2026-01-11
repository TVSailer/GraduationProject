using Admin.View;
using Admin.View.Moduls.Event;
using Admin.View.Moduls.Lesson;
using Admin.View.Moduls.Teacher;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using Admin.ViewModels.Teachers;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.DI;
using WinFormsApp1.View;

namespace WinFormsApp1
{
    internal static class AdminDI
    {
        private static DIContainer container;

        public static DIContainer Container => container ??= ConfigurationContainer();

        private static DIContainer ConfigurationContainer()
        {
            var register = new RegisterDI();

            register.RegisterSingleton<ApplicationDbContext>();

            register.Register<Repository<LessonEntity>, LessonsRepository>(ServiceLifetime.Singleton);
            register.Register<TeacherRepository>();
            register.Register<EventRepository>();
            register.Register<NewsRepository>();

            //register.RegisterScope<EventMinControlViewModel>();
            //register.RegisterScope<EventMaxControlViewModel>();
            //register.RegisterScope<EventMenegmentModelView>();

            //register.RegisterScope<EventAddingView>();
            //register.RegisterScope<EventDetailsView>();
            //register.RegisterScope<EventManagementView>();

            //register.RegisterScope<TeacherManagementModelView>();

            //register.RegisterScope<TeacherManagementView>();

            register.Register<ViewModel<LessonEntity>, LessonViewModel>(ServiceLifetime.Scoped);
            register.Register<ManagmentModelView<LessonEntity>>();

            register.Register<UI<LessonEntity>>();
            register.Register<ManagementView<LessonEntity, LessonCard>>();

            register.RegisterSingleton<AdminMainView>();
            register.RegisterSingleton<AdminMainViewModel>();

            return new DIContainer(register.Descriptors, false);
        }

        public static T GetService<T>() where T : class
        {
            return Container.GetService<T>();
        }
        
        public static object GetService(Type serviceType)
        {
            return Container.GetService(serviceType);
        }

        public static DIContainer CreateDIScope()
            => new DIContainer(Container.Description, true);
    }
}

