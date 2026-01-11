using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.View.ViewForm;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Migrations;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using Logica.DI;
using Logica.Img;
using System.Windows.Input;
using WinFormsApp1;
using NotNullAttribute = Logica.CustomAttribute.NotNullAttribute;

namespace Admin.ViewModels.Lesson
{
    public class LessonViewModel : ViewModelWithImages<LessonEntity>
    {
        [ButtonInfo("Выбрать преподователя")] public ICommand OnBindingTeacher { get; protected set; }
        [ButtonInfo("Создать расписание")] public ICommand OnCreateSchedule { get; protected set; }
        [ButtonInfo("Управление посетителями")] public ICommand OnControlVisitros { get; private set; }
        [ButtonInfo("Управление посещаемостью")] public ICommand OnControlDateAttendances { get; private set; }
        [ButtonInfo("Управление отзывами")] public ICommand OnControlReview { get; private set; }
        

        [RequiredCustom]
        [FieldInfoViewModel(nameof(Entity.Name))]
        [FieldInfoUI("Название:*", "Введите название")] 
        public string Name { get; set => field = Set(value); }

        [RequiredCustom]
        [FieldInfoViewModel(nameof(Entity.Description))]
        [FieldInfoUI("Описание:*", "Введите описание мероприятия", true, false, 100)] 
        public string Description { get; set => field = Set(value); }

        [RequiredCustom]
        [FieldInfoViewModel(nameof(Entity.Category))]
        [FieldInfoUI("Категория:*", "Введите категорию")] 
        public string Category { get; set => field = Set(value); }

        [RequiredCustom]
        [FieldInfoViewModel(nameof(Entity.Schedule))]
        [FieldInfoUI("Расписание:*", "Введите расписание, например: Пн, Ср, Пт 19:00-20:30")]
        public string Schedule { get; set => field = Set(value); }

        [RequiredCustom]
        [FieldInfoViewModel(nameof(Entity.Location))]
        [FieldInfoUI("Место проведения:*", "Введите место проведения")]
        public string Location { get; set => field = Set(value); }

        [MaxParticipants]
        [FieldInfoViewModel(nameof(Entity.MaxParticipants))]
        [FieldInfoUI("Кол. участников:*", "Введите кол-во участников")]
        public int MaxParticipants { get; set => field = Set(value); }

        [NotNull]
        [FieldInfoViewModel(nameof(Entity.Teacher))]
        [FieldInfoUI("Преподователь:*", "Выберите преподователя", false, true)]
        public TeacherEntity Teacher { get; set => field = Set(value); }

        private List<ImgLessonEntity>? imgLessonEntities = new();
        private List<ReviewEntity>? reviewEntities = new();
        private List<DateAttendanceEntity>? dateAttendances = new();
        private List<VisitorEntity>? visitorEntities = new();

        private readonly List<TeacherEntity> teacherEntities;

        protected override Action actionSave { get; set; }

        public LessonViewModel() { }

        public LessonViewModel(LessonsRepository lessonsRepository, TeacherRepository teacherRepository) : base(lessonsRepository)
        {
            actionSave = () => lessonsRepository.AddRelationWithLesson(Teacher, Entity);

            teacherEntities = teacherRepository.Get();

            OnBack = new MainCommand(
                _ => AdminDI.GetService<ManagementView<LessonEntity, LessonCard>>().InitializeComponents(null));

            OnBindingTeacher = new MainCommand(
                _ => Teacher = new LessonLinkingToTeacherView(teacherEntities).InitializeComponents().Teacher);
        }
    }
}
