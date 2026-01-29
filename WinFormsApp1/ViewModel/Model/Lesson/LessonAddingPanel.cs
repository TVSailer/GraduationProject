using System.Windows.Input;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Ninject;

namespace Admin.ViewModels.Lesson
{
    [LinkingCommand(nameof(ManagmentModelView<>.OnLoadAddingView))]
    public class LessonAddingPanel : LessonData, IAddingPanel<LessonEntity>
    {
        [ButtonInfoUI("Сохранить")] public ICommand OnSave { get; protected set; }

        public LessonAddingPanel(
            LessonsRepository lessonsRepository, 
            TeacherRepository teacherRepository, 
            LessonCategoryRepositroy lessonCategoryRepositroy) : base(teacherRepository, lessonCategoryRepositroy)
        {
            OnSave = new MainCommand(
                _ => TryValidObject(() => lessonsRepository.Add(GenericRepositoryEntity.GetEntity())));
        }
    }
}
