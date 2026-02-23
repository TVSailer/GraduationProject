using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;

namespace Admin.ViewModels.Lesson
{
    public class LessonSearch : IParametersSearch<LessonEntity, LessonFieldSearch>
    {
        public Func<LessonFieldSearch, List<LessonEntity>, List<LessonEntity>> SearchFunc => 
            (obj, entitys) =>
            {
                return entitys
                    .Where(e => obj.Category == null || obj.Category.Equals("") || e.Category.Equals(obj.Category))
                    .Where(e => e.Name.StartsWith(obj.Name ?? ""))
                    .Where(e => e.Teacher.FIO.Name.StartsWith(obj.TeacherName ?? ""))
                    .Where(e => e.Teacher.FIO.Surname.StartsWith(obj.TeacherSurname ?? ""))
                    .ToList();
            
            };
    }
}
