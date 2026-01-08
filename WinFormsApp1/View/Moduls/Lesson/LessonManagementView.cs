using Admin.ViewModel.Lesson;
using DataAccess.Postgres.Models;
using Logica.DI;
using WinFormsApp1;
using WinFormsApp1.View;

namespace Admin.View.Moduls.Lesson
{
    public class LessonManagementView : ManagementView<LessonEntity>
    {
        private new readonly LessonManagmentViewModel context;

        public LessonManagementView(AdminMainView mainForm, LessonManagmentViewModel viewModel) : base(mainForm, viewModel)
        {
            context = viewModel;

            form.Text = "🎨 Управление кружками";
        }

        public override ObjectCard<LessonEntity> CreateCard(LessonEntity entity)
            => new LessonCard(entity);

        protected override Control LoadSerchPanel()
        {
            return new Panel();
        }
    }
}


