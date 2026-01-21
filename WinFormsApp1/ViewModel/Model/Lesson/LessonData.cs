using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.ViewModel.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using System.Windows.Input;
using WinFormsApp1;
using NotNullAttribute = Logica.CustomAttribute.NotNullAttribute;

namespace Admin.ViewModels.Lesson
{
    public class LessonData : ViewModelWithImages<LessonEntity>
    {
        public readonly List<LessonCategoryEntity> categories;
        public readonly List<TeacherEntity> teachers;

        [RequiredCustom]
        [LinkingEntity("Name")]
        [BaseFieldUI("Название:*", "Введите название")]
        public string Name { get; set => TryValidProperty(ref field, value); }

        [RequiredCustom]
        [LinkingEntity("Description")]
        [MultilineFieldUI()]
        public string Description { get; set => TryValidProperty(ref field, value); }

        [LinkingEntity("Schedule")]
        public List<LessonScheduleEntity>? Schedule { get; 
            set
            {
                TryValidProperty(ref field, value);
                OnPropertyChanged(nameof(ScheduleParse));
            }
        }

        [RequiredCustom]
        [ReadOnlyFieldUI("Расписание*:", "Создайте расписание")]
        public string? ScheduleParse
        {
            get
            {
                if (Schedule is null)
                {
                    return null;
                }
                string value = null;
                Schedule.ForEach(s => value += $"{s.Day.ToDescriptionString().Substring(0, 4)}. {s.Start}-{s.End} ");
                return value;
            }
        }

        [RequiredCustom]
        [LinkingEntity("Location")]
        [BaseFieldUI("Место проведения:*", "Введите место проведения")]
        public string Location { get; set => TryValidProperty(ref field, value); }

        [MaxParticipants]
        [LinkingEntity("MaxParticipants")]
        [NumericFieldUI("Кол. участников:*")]
        public int MaxParticipants { get; set => TryValidProperty(ref field, value); }

        [RequiredCustom]
        [LinkingEntity("Category")]
        [ComboBoxFieldUI("Категория:*", nameof(categories))]
        public LessonCategoryEntity Category { get; set => 
                TryValidProperty(ref field, value); }

        [NotNull]
        [LinkingEntity("Teacher")]
        [ComboBoxFieldUI("Преподователь:*", nameof(teachers))]
        public TeacherEntity Teacher { get; 
            set => TryValidProperty(ref field, value); }

        [ButtonInfoUI("Создать расписание")] public ICommand OnCreateSchedule { get; protected set; }

        public LessonData(TeacherRepository teacherRepository,  LessonCategoryRepositroy eventCategoryRepositroy)
        {
            categories = eventCategoryRepositroy.Get();
            teachers = teacherRepository.Get();

            OnBack = new MainCommand(
                _ => AdminDI.GetService<ManagementView<LessonEntity, LessonCard, LessonAddingPanel, LessonDetailsPanel>>().InitializeComponents(null));

            OnCreateSchedule = new MainCommand(
                _ => new ScheduleView(Schedule, s => Schedule = s).ShowDialog());
        }
    }
}

