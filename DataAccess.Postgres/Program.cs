// See https://aka.ms/new-console-template for more information


using DataAccess.Postgres;

using (var context = new ApplicationDbContext())
{
    //LessonEntity lesson = new LessonEntity { Name = "ksldjga"};
    //LessonEntity lesson1 = new LessonEntity { Name = "ksga"};
    //context.Lessons.Add(lesson);
    //context.Lessons.Add(lesson1);
    //context.SaveChanges();

    /*var lessons = context.Lessons.Inclede(x => x.Person) - объединяет таблицы

    foreach (var lesson in lessons)
        Console.WriteLine($"{ lesson.Name }");*/
}
