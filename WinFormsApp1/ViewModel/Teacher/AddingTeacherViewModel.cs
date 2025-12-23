using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Teachers
{
    public class AddingTeacherViewModel : TeacherDataViewModel
    {
        public AddingTeacherViewModel(TeacherRepository teacherRepository, LessonsRepository lessonsRepository) : base(teacherRepository, lessonsRepository)
        {

        }
    }
}

//public class LinkingTeacherToLessonViewModel
//{
//    public readonly List<LessonEntity> lessons;

//    public LinkingTeacherToLessonViewModel(LessonsRepository lessonsRepository)
//    {
//        lessons = lessonsRepository.Get();
//    }
//}

//public class LindingTeacherToLessonView : IViewForm
//{
//    private readonly LinkingTeacherToLessonViewModel context;

//    public LindingTeacherToLessonView(LinkingTeacherToLessonViewModel viewModel)
//    {
//        context = viewModel;
//    }

//    public Form InitializeComponents()
//        => new Form()
//        .With(f => f.Size = new Size(800, 1000))
//        .With(f => f.Controls.Add(
//            FactoryElements.CheckedListBox()
//            .With(cb => cb.DataContext = context.lessons)));
//}