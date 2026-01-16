using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Admin.ViewModel.Lesson
{
    public class LessonDetailsPanel : LessonData, IDetalsPanel<LessonEntity>
    {
        [ButtonInfoUI("Создать расписание")] public ICommand OnCreateSchedule { get; protected set; }
        [ButtonInfoUI("Управление посетителями")] public ICommand OnControlVisitros { get; private set; }
        [ButtonInfoUI("Управление посещаемостью")] public ICommand OnControlDateAttendances { get; private set; }
        [ButtonInfoUI("Управление отзывами")] public ICommand OnControlReview { get; private set; }
        [ButtonInfoUI("Удалить")] public ICommand OnDelete { get; protected set; }
        [ButtonInfoUI("Обновить")] public ICommand OnUpdate { get; protected set; }

        private List<ImgLessonEntity>? imgLessonEntities = new();
        private List<ReviewEntity>? reviewEntities = new();
        private List<DateAttendanceEntity>? dateAttendances = new();
        private List<VisitorEntity>? visitorEntities = new();

        private readonly List<TeacherEntity> teacherEntities;

        public LessonDetailsPanel(LessonsRepository lessonsRepository, TeacherRepository teacherRepository) : base(teacherRepository)
        {
            OnUpdate = new MainCommand(
                _ => TryValidObject(() => lessonsRepository.Update(Entity.Id, Entity)));

            OnDelete = new MainCommand(
                _ =>
                {
                    lessonsRepository.Delete(Entity);
                    OnBack.Execute(this);
                });
        }
    }
}
