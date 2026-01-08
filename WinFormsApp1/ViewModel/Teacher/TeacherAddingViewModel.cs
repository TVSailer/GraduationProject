using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Teachers
{
    public class TeacherAddingViewModel : TeacherDataViewModel
    {
        public TeacherAddingViewModel(TeacherRepository teacherRepository, LessonsRepository lessonsRepository) : base(teacherRepository, lessonsRepository)
        {

        }
    }
}
