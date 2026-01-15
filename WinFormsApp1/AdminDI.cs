using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.ViewModel.Lesson;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
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
            var register = new ServiceCollection();

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


            RegisterSistem<LessonEntity, LessonDetailsPanel>(register);
            RegisterSistem<LessonEntity, LessonAddingPanel>(register);
            register.Register<
                ParametrsFromManagmentMV<LessonEntity, LessonAddingPanel>>(ServiceLifetime.Transient);
            register.Register<
                ParametrsFromManagmentMV<LessonEntity, LessonDetailsPanel>>(ServiceLifetime.Transient);

            register.Register<ManagmentModelView<LessonEntity, LessonAddingPanel, LessonDetailsPanel>>();
            register.Register<ManagementView<LessonEntity,  LessonCard, LessonAddingPanel, LessonDetailsPanel>>();

            register.RegisterSingleton<AdminMainView>();
            register.RegisterSingleton<AdminMainViewModel>();

            return new DIContainer(register.Descriptors, false);
        }

        public static void RegisterSistem<TEntity, TViewModel>(ServiceCollection register)
            where TEntity : Entity,new()
            where TViewModel : class, IViewModele<TEntity>
        {
            register.Register<GenericRepositoryEntity<TEntity, TViewModel>>();
            register.Register<TViewModel>(ServiceLifetime.Scoped);
            register.Register<UIEntity<TEntity, TViewModel>>();
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

