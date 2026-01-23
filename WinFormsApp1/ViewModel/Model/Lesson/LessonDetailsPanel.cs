using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.ViewModel.WordWithEntity;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using Ninject;

namespace Admin.ViewModel.Lesson
{
    [LinkingCommand(nameof(ManagmentModelView<>.OnLoadDetailsView))]
    public class LessonDetailsPanel : LessonData
    {
        [ButtonInfoUI("Управление посетителями")] public ICommand OnControlVisitros { get; private set; }
        [ButtonInfoUI("Управление посещаемостью")] public ICommand OnControlDateAttendances { get; private set; }
        [ButtonInfoUI("Управление отзывами")] public ICommand OnControlReview { get; private set; }
        [ButtonInfoUI("Удалить")] public ICommand OnDelete { get; protected set; }
        [ButtonInfoUI("Обновить")] public ICommand OnUpdate { get; protected set; }

        private List<ReviewEntity>? reviewEntities = new();
        private List<DateAttendanceEntity>? dateAttendances = new();
        private List<VisitorEntity>? visitorEntities = new();

        
        private readonly List<TeacherEntity> teacherEntities;

        public LessonDetailsPanel(
            LessonsRepository lessonsRepository, 
            TeacherRepository teacherRepository, 
            LessonCategoryRepositroy lessonCategoryRepositroy) : base(teacherRepository, lessonCategoryRepositroy)
        {
            OnUpdate = new MainCommand(
                _ => TryValidObject(() => lessonsRepository.Update(GenericRepositoryEntity.Entity.Id, GenericRepositoryEntity.Entity)));

            OnDelete = new MainCommand(_ =>
            {
                {
                    lessonsRepository.Delete(GenericRepositoryEntity.Entity);
                    OnBack.Execute(this);
                }
            });
        }
    }

}
