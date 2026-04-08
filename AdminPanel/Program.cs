using Admin.DI;
using Admin.ViewModel.Model.AdminMain;
using DataAccess.PostgreSQL;
using Domain.Entitys;
using Domain.Entitys.ComplexType;
using Domain.Repository;
using Domain.ValidObject;
using UserInterface.Service.View.Base;
using Day = Domain.Enum.Day;

namespace Admin;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var di = new MainDI();

        var controlView = di.GetService<IControlView>();

        controlView.LoadView<AdminPanelViewModel>();

        //di.GetService<TestData>();

        Application.Run(controlView.Form);
    }
}

public class TestData {
    public TestData(ApplicationDbContext dbContext, IRepository<AuthEntity> repositoryA)
    {
        List<string> images = [];
        for (int i = 0; i < 10; i++)
            images.Add($"C://Users/tereg/Pictures/2025-11-30/326{i}.jpg");

        var category = new CategoryEntity("Развлечение");

        dbContext.Add(category);

        for (int i = 0; i < 10; i++)
        {
            dbContext.Add(new NewsEntity(
                $"Название {i}",
                $"Контент {i}",
                "30.11.2026",
                category,
                $"Автор {i}",
                images
                ));

            dbContext.Add(
                new EventEntity(
                    $"Название {i}",
                    images[0],
                    $"Описание {i}",
                    $"Локация {i}",
                    $"https//:k{i}",
                    $"Огранизатор {i}",
                    new EventEntitySchedule(
                        "11:00",
                        "12:00",
                        "30.11.2027"),
                    category,
                    images
                ));

            var auth = new AuthEntity(
                LoginValidObject.Create($"Фамилия {i}"), 
                PasswordValidObject.Create(repositoryA.Get().Select(a => a.Password).ToArray())
                );

            dbContext.Add(auth);

            var teacher = new TeacherEntity(
                images[0],
                $"Имя {i}",
                $"Фамилия {i}",
                $"Отчество {i}",
                "30.11.2005",
                "89898342334",
                auth
            );

            dbContext.Add(teacher);

            var lesson = new LessonEntity(
                $"Название {i}",
                $"Описание {i}",
                $"Локация {i}",
                i,
                category,
                teacher,
                [
                    new LessonScheduleEntity(
                        TimeOnly.Parse("11:00"),
                        TimeOnly.Parse("12:00"),
                        Day.Friday),
                    new LessonScheduleEntity(
                        TimeOnly.Parse("11:00"),
                        TimeOnly.Parse("12:00"),
                        Day.Saturday),
                    new LessonScheduleEntity(
                        TimeOnly.Parse("11:00"),
                        TimeOnly.Parse("12:00"),
                        Day.Tuesday),
                ],
                images
            );

            dbContext.Add(lesson);

            var visitor = new VisitorEntity(
                images[0],
                $"Имя {i}",
                $"Фамилия {i}",
                $"Отчество {i}",
                "30.11.2005",
                "89898342334",
                auth
            );

            visitor.AddLesson(lesson);

            dbContext.Add(visitor);
            dbContext.SaveChanges();
        }
    }
}