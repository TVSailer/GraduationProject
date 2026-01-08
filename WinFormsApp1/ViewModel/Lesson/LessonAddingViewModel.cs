using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;

namespace Admin.ViewModel.Lesson
{
    public class LessonAddingViewModel : LessonDataViewModel
    {
        public LessonAddingViewModel(LessonsRepository lessonsRepository, TeacherRepository teacherRepository) : base(lessonsRepository, teacherRepository)
        {
            
        }
    }
}
