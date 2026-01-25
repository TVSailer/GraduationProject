using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Ninject;

    internal static class AdminDI
    {
        

        private static StandardKernel container;

        public static StandardKernel Container => container ??= ConfigurationContainer();

        private static StandardKernel ConfigurationContainer()
        {
            var conteiner = new StandardKernel(
                new LessonModule(), 
                new EventModule(), 
                new TeacherModule());

            var db = new ApplicationDbContext();

            conteiner.Bind<ApplicationDbContext>().ToConstant(db).InSingletonScope();

            conteiner.Bind<AdminMainView>().ToSelf().InSingletonScope();
            conteiner.Bind<AdminMainViewModel>().ToSelf().InSingletonScope();

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

            // db.Teachers.ExecuteUpdate(t => t.SetProperty(t => t.Password, BCrypt.Net.BCrypt.HashPassword("1234")));
            // db.SaveChanges();

            return conteiner;
        }

        public static T GetService<T>() where T : class {
            return Container.Get<T>();
        }
    }

