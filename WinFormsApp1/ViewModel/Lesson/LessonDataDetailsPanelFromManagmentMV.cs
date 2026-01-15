using Admin.ViewModels;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Lesson
{
    public class LessonDataDetailsPanelFromManagmentMV : ParametrsFromManagmentMV<LessonEntity, LessonDetailsPanel>, IDetalsPanel<LessonEntity>
    {
        public LessonEntity Entity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
