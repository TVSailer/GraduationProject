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
        [FieldInfo("Название:*", "Введите название")] 
        public string Name { get; set => Set(ref field, value); }

        [RequiredCustom] 
        [FieldInfo("Описание:*", "Введите описание мероприятия", true, false, 100)] 
        public string Description { get; set => Set(ref field, value); }

        [RequiredCustom] 
        [FieldInfo("Категория:*", "Введите категорию")] 
        public string Category { get; set => Set(ref field, value); }

        [RequiredCustom]
        [FieldInfo("Расписание:*", "Введите расписание, например: Пн, Ср, Пт 19:00-20:30")]
        public string Schedule { get; set => Set(ref field, value); }

        [RequiredCustom]
        [FieldInfo("Место проведения:*", "Введите место проведения")]
        public string Location { get; set => Set(ref field, value); }

        [MaxParticipants]
        [FieldInfo("Кол. участников:*", "Введите кол-во участников")]
        public string MaxParticipants { get; set => Set(ref field, value); }

        [NotNull]
        [FieldInfo("Преподователь:*", "Выберите преподователя", false, true)]
        public TeacherEntity Teacher { get; set => Set(ref field, value); }

        private List<ReviewEntity>? reviewEntities = new();
        private List<DateAttendanceEntity>? dateAttendances = new();
        private List<VisitorEntity>? visitorEntities = new();

        private readonly List<TeacherEntity> teacherEntities;

        public LessonEntity LessonEntity
        {
            get
            {
                Entity.Name = Name;
                Entity.Description = Description;
                Entity.Category = Category;
                Entity.Schedule = Schedule;
                Entity.Location = Location;
                Entity.MaxParticipants = int.Parse(MaxParticipants);
                Entity.Teacher = Teacher;
                //field.Dates = dateAttendances;
                //field.Visitors = visitorEntities;
                //field.Reviews = reviewEntities;

                SelectedImg.ForEach(i => field.ImgsLesson.Add(new ImgLessonEntity(i.Key)));

                return field;
            }
            set
            {
                if (value is null) throw new ArgumentNullException();

                Name = value.Name;
                Description = value.Description;
                Category = value.Category;
                Schedule = value.Schedule;
                Location = value.Location;
                MaxParticipants = value.MaxParticipants.ToString();
                Teacher = value.Teacher;
                dateAttendances = value.Dates;
                visitorEntities = value.Visitors;
                reviewEntities = value.Reviews;

                value.ImgsLesson?.ForEach(img => SelectedImg.Add(img.Url, false));

                Entity = value;

                field = value;
            }
        } = new();

        protected override Action actionSave { get; set; }

        public LessonViewModel() { }

        public LessonViewModel(LessonsRepository lessonsRepository, TeacherRepository teacherRepository) : base(lessonsRepository)
        {
            actionSave = () => lessonsRepository.AddRelationWithLesson(Teacher, LessonEntity);

            teacherEntities = teacherRepository.Get();

            OnBack = new MainCommand(
                _ => AdminDI.GetService<ManagementView<LessonEntity, LessonCard>>().InitializeComponents(null));

            OnBindingTeacher = new MainCommand(
                _ => Teacher = new LessonLinkingToTeacherView(teacherEntities).InitializeComponents().Teacher);
        }

        public override IViewModel<LessonEntity> Initialize(object value)
        {
            return this;
        }

        public override void SetData(LessonEntity value)
        {
            LessonEntity = value;
        }
    }
}
