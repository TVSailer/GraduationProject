using System.Windows.Input;
using Admin.View;
using Admin.ViewModel.Interface;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Ninject;

namespace Admin.ViewModel.Lesson
{
    [LinkingCommand(nameof(ManagmentModelView<>.OnLoadDetailsView))]
    public class LessonDetailsPanel : LessonData, IDetailsPanel<LessonEntity>
    {
        [ButtonInfoUI("Управление посетителями")] public ICommand OnControlVisitors { get; private set; }
        [ButtonInfoUI("Управление посещаемостью")] public ICommand OnControlDateAttendances { get; private set; }
        [ButtonInfoUI("Управление отзывами")] public ICommand OnControlReview { get; private set; }
        [ButtonInfoUI("Удалить")] public ICommand OnDelete { get; protected set; }
        [ButtonInfoUI("Обновить")] public ICommand OnUpdate { get; protected set; }

        public LessonDetailsPanel(
            LessonsRepository lessonsRepository, 
            TeacherRepository teacherRepository, 
            LessonCategoryRepositroy lessonCategoryRepository) : base(teacherRepository, lessonCategoryRepository)
        {
            OnUpdate = new MainCommand(
                _ => TryValidObject(() => lessonsRepository.Update(GenericRepositoryEntity.Id, GenericRepositoryEntity.GetEntity())));

            OnDelete = new MainCommand(_ =>
            {
                {
                    lessonsRepository.Delete(GenericRepositoryEntity.Id);
                    OnBack.Execute(this);
                }
            });
        }

        public void SetEntity(LessonEntity entity)
        {
            GenericRepositoryEntity.SetEntity(entity);
        }
    }

}
