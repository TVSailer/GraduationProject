using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using WinFormsApp1;

namespace Admin.ViewModel.Lesson
{
    public class LessonDataAddingPanelFromManagmentMV : ParametrsFromManagmentMV<LessonEntity, LessonAddingPanel>, IAddingPanel<LessonEntity>
    {
        public LessonEntity Entity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
