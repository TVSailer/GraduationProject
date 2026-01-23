using Admin.View.Moduls.Event;
using Admin.ViewModel.MovelView;
using Admin.ViewModel.WordWithEntity;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.DI;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using WinFormsApp1.View;
using WinFormsApp1.ViewModelEntity.Event;

namespace WinFormsApp1
{
    internal static class AdminDI
    {
        

        private static StandardKernel container;

        public static StandardKernel Container => container ??= ConfigurationContainer();

        private static StandardKernel ConfigurationContainer()
        {
            var conteiner = new StandardKernel(new LessonModule(), new EventModule());

            var db = new ApplicationDbContext();

            conteiner.Bind<Repository<TeacherEntity>>().To<TeacherRepository>();
            conteiner.Bind<AdminMainView>().ToSelf().InSingletonScope();
            conteiner.Bind<AdminMainViewModel>().ToSelf().InSingletonScope();
            conteiner.Bind<ApplicationDbContext>().ToConstant(db);

            // db.AddRange(
            //     new EventCategoryEntity("Спорт"),
            //     new EventCategoryEntity("Творчесво"),
            //     new EventCategoryEntity("Наука")
            //     );

            // db.AddRange(
            //     new TeacherEntity("dsf", "sdf", "lgh", "22.11.2004", "88989988989", ""),
            //     new TeacherEntity("jtr", "D", "DT", "22.11.2004", "88989988989", ""),
            //     new TeacherEntity("SREG", "AERF", "SASF", "22.11.2004", "88989988989", "")
            //     );
            // db.SaveChanges();



            return conteiner;
        }

        public static IServiceScope CreateDIScope()
            => Container.CreateScope();

        public static T GetService<T>() where T : class {
            return Container.Get<T>();
        }
    }
}

