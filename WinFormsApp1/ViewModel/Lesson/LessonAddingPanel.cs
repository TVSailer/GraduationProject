using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;

namespace Admin.ViewModels.Lesson
{
    
    public class LessonAddingPanel : LessonData, IAddingPanel<LessonEntity>
    {
        [ButtonInfoUI("Сохранить")] public ICommand OnSave { get; protected set; }

        public LessonAddingPanel(LessonsRepository lessonsRepository, TeacherRepository teacherRepository) : base(teacherRepository)
        {
            OnSave = new MainCommand(
                _ => TryValidObject(() => lessonsRepository.AddRelationWithLesson(Teacher, Entity)));
        }
    }
}
