using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;

namespace Admin.ViewModels.Lesson
{
    
    public class LessonAddingPanel : LessonData, IAddingPanel<LessonEntity>
    {
        [ButtonInfoUI("Сохранить")] public ICommand OnSave { get; protected set; }

        public LessonAddingPanel(LessonsRepository lessonsRepository, TeacherRepository teacherRepository, LessonCategoryRepositroy lessonCategoryRepositroy) : base(teacherRepository, lessonCategoryRepositroy)
        {
            OnSave = new MainCommand(
                _ => TryValidObject(() => lessonsRepository.Add(Entity)));
        }
    }
}
