using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WinFormsApp1;
using NotNullAttribute = Logica.CustomAttribute.NotNullAttribute;

namespace Admin.ViewModels.Lesson
{
    public class LessonAddingPanel : LessonData
    {
        [ButtonInfoUI("Сохранить")] public ICommand OnSave { get; protected set; }

        

        public LessonAddingPanel(LessonsRepository lessonsRepository, TeacherRepository teacherRepository) : base(teacherRepository)
        {
            OnSave = new MainCommand(
                _ => TryValidObject(lessonsRepository.AddRelationWithLesson(Teacher, Entity)));
        }
    }
}
