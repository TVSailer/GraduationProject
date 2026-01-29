using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using System.Windows.Input;
using NotNullAttribute = Logica.CustomAttribute.NotNullAttribute;

namespace Admin.ViewModels.Lesson
{
    public class LessonData : ViewModelWithImages<LessonEntity>
    {
        public readonly List<LessonCategoryEntity> categories;
        public readonly List<TeacherEntity> teachers;

        [RequiredCustom, LinkingEntity("Name"), BaseFieldUi("Название:*", "Введите название")]
        public string Name
        {
            get;
            set => TryValidProperty(ref field, value);
        }

        [RequiredCustom, LinkingEntity("Description"), MultilineFieldUi()]
        public string Description
        {
            get;
            set => TryValidProperty(ref field, value);
        }

        [LinkingEntity("Schedule")]
        public List<LessonScheduleEntity>? Schedule
        {
            get;
            set
            {
                TryValidProperty(ref field, value);
                OnPropertyChanged(nameof(ScheduleParse));
            }
        }

        [RequiredCustom, ReadOnlyFieldUi("Расписание*:", "Создайте расписание")]
        public string? ScheduleParse => Schedule?.ParseSchedule();

        [RequiredCustom, LinkingEntity("Location"), BaseFieldUi("Место проведения:*", "Введите место проведения")]
        public string Location
        {
            get;
            set => TryValidProperty(ref field, value);
        }

        [MaxParticipants, LinkingEntity("MaxParticipants"), NumericFieldUi("Кол. участников:*")]
        public int MaxParticipants
        {
            get;
            set => TryValidProperty(ref field, value);
        } = 1;

        [RequiredCustom, LinkingEntity("Category"), ComboBoxFieldUi("Категория:*", nameof(categories))]
        public LessonCategoryEntity Category
        {
            get;
            set => TryValidProperty(ref field, value);
        }

        [NotNull, LinkingEntity("Teacher"), ComboBoxFieldUi("Преподователь:*", nameof(teachers))]
        public TeacherEntity Teacher
        {
            get;
            set => TryValidProperty(ref field, value);
        }

        [ButtonInfoUI("Создать расписание")] public ICommand OnCreateSchedule { get; protected set; }

        public LessonData(
            TeacherRepository teacherRepository, 
            LessonCategoryRepositroy eventCategoryRepositroy) : base(new MainCommand(_ =>
                AdminDI.GetService<ManagementView<LessonEntity, LessonCard>>().InitializeComponents(null)))
        {
            categories = eventCategoryRepositroy.Get();
            teachers = teacherRepository.Get();

            OnCreateSchedule = new MainCommand(_ => new ScheduleView(Schedule, s => Schedule = s).ShowDialog());
        }
    }
}