using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using WinFormsApp1.View;

namespace Admin.ViewModel.Lesson
{
    public class LessonManagmentViewModel : AbstractManagmentModelView
    {
        private List<LessonEntity> lessonEntities = new();

        public override ICommand OnBack { get; set; }
        public override ICommand OnLoadAddingView { get; set; }
        public override ICommand OnLoadDetailsView { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnClearSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<LessonEntity> LessonEntities
        {
            get => lessonEntities;
            set
            {
                if (lessonEntities.SequenceEqual(value))
                    return;
                lessonEntities = value;
                OnPropertyChanged();
            }
        }

        public LessonManagmentViewModel(AdminMainView mainForm, LessonsRepository lessonsRepository)
        {
            LessonEntities = lessonsRepository.Get();

            OnBack = new MainCommand(
                _ => mainForm.InitializeComponents());
        }
    }
}
