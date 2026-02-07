using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModels.Lesson
{
    public class LessonSearch : SearchEntity<LessonEntity, LessonFieldSearch>
    {
        public LessonSearch(LessonsRepository lessonsRepository, LessonCategoryRepositroy categoryRepositroy) : base(lessonsRepository.Get, new LessonFieldSearch(categoryRepositroy.Get()), (obj, entitys) =>
            entitys
                    .Where(e => obj.Category.Equals(obj.category[0]) || e.Category.Equals(obj.Category))
                    .Where(e => e.Name.StartsWith(obj.Name))
                    .Where(e => e.Teacher.FIO.Name.StartsWith(obj.TeacherName))
                    .Where(e => e.Teacher.FIO.Surname.StartsWith(obj.TeacherSurname))
                    .ToList())
        {
        }
    }
}
