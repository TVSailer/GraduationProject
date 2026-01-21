using Admin.View;
using Admin.View.Moduls.Event;
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
using WinFormsApp1.ViewModelEntity.Event;

namespace WinFormsApp1
{
    internal static class AdminDI
    {
        private static DIContainer container;

        public static DIContainer Container => container ??= ConfigurationContainer();

        private static DIContainer ConfigurationContainer()
        {
            var register = new ServiceCollection();

            var dbContext = new ApplicationDbContext();

            //dbContext.AddRange(
            //    new LessonCategoryEntity("Спорт"),
            //    new LessonCategoryEntity("Творчесво"),
            //    new LessonCategoryEntity("Наука")
            //    );

            //dbContext.AddRange(
            //    new TeacherEntity("dsf", "sdf", "lgh", "22.11.2004", "88989988989", ""),
            //    new TeacherEntity("jtr", "D", "DT", "22.11.2004", "88989988989", ""),
            //    new TeacherEntity("SREG", "AERF", "SASF", "22.11.2004", "88989988989", "")
            //    );
            //dbContext.SaveChanges();

            register.RegisterSingelton(dbContext);

            register.Register<Repository<LessonEntity>, LessonsRepository>(ServiceLifetime.Singleton);
            register.Register<Repository<LessonCategoryEntity>, LessonCategoryRepositroy>(ServiceLifetime.Singleton);
            register.Register<TeacherRepository>();
            register.Register<Repository<EventEntity>, EventRepository>();
            register.Register<NewsRepository>();


            RegisterSistem<EventEntity, EventAddingPanel>(register);
            RegisterSistem<EventEntity, EventDetailsPanel>(register);

            register.Register<ManagmentModelView<EventEntity, EventAddingPanel, EventDetailsPanel>>();
            register.Register<ManagementView<EventEntity, EventCard, EventAddingPanel, EventDetailsPanel>>();
            register.Register<SerchManagment<EventEntity>, EventSerch>();

            RegisterSistem<LessonEntity, LessonDetailsPanel>(register);
            RegisterSistem<LessonEntity, LessonAddingPanel>(register);

            register.Register<ManagmentModelView<LessonEntity, LessonAddingPanel, LessonDetailsPanel>>();
            register.Register<ManagementView<LessonEntity,  LessonCard, LessonAddingPanel, LessonDetailsPanel>>();
            register.Register<SerchManagment<LessonEntity>, LessonSerch>();

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
            register.Register<
                ParametrsFromManagmentMV<TEntity, TViewModel>>();
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

