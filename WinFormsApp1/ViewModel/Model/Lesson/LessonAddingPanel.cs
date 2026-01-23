using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.ViewModel.WordWithEntity;
using Ninject;

namespace Admin.ViewModels.Lesson
{
    [LinkingCommand(nameof(ManagmentModelView<>.OnLoadAddingView))]
    public class LessonAddingPanel : LessonData
    {
        [ButtonInfoUI("Сохранить")] public ICommand OnSave { get; protected set; }

        public LessonAddingPanel(
            LessonsRepository lessonsRepository, 
            TeacherRepository teacherRepository, 
            LessonCategoryRepositroy lessonCategoryRepositroy) : base(teacherRepository, lessonCategoryRepositroy)
        {
            OnSave = new MainCommand(
                _ => TryValidObject(() => lessonsRepository.Add(GenericRepositoryEntity.Entity)));
        }
    }
}
