using Admin.ViewModel.MovelView;
using Admin.ViewModels.NotifuPropertyViewModel;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using System.Windows.Input;
using NotNullAttribute = Logica.CustomAttribute.NotNullAttribute;

namespace Admin.ViewModels.Lesson
{
    public class LessonData : ViewModelWithImages<LessonEntity, ImgLessonEntity>
    {
        [RequiredCustom]
        [LinkingEntity("Name")]
        [FieldInfoUI("Название:*", "Введите название")]
        public string Name { get; set => field = Set(value); }

        [RequiredCustom]
        [LinkingEntity("Description")]
        [FieldInfoUI("Описание:*", "Введите описание мероприятия", true, false, 100)]
        public string Description { get; set => field = Set(value); }

        [RequiredCustom]
        [LinkingEntity("Category")]
        [FieldInfoUI("Категория:*", "Введите категорию")]
        public string Category { get; set => field = Set(value); }

        [RequiredCustom]
        [LinkingEntity("Schedule")]
        [FieldInfoUI("Расписание:*", "Введите расписание, например: Пн, Ср, Пт 19:00-20:30")]
        public string Schedule { get; set => field = Set(value); }

        [RequiredCustom]
        [LinkingEntity("Location")]
        [FieldInfoUI("Место проведения:*", "Введите место проведения")]
        public string Location { get; set => field = Set(value); }

        [MaxParticipants]
        [LinkingEntity("MaxParticipants"))]
        [FieldInfoUI("Кол. участников:*", "Введите кол-во участников")]
        public int MaxParticipants { get; set => field = Set(value); }

        [NotNull]
        [LinkingEntity("Teacher")]
        [FieldInfoUI("Преподователь:*", "Выберите преподователя", false, true)]
        public TeacherEntity Teacher { get; set => field = Set(value); }


        [ButtonInfoUI("Выбрать преподователя")]
        public ICommand OnBindingTeacher { get; protected set; }

        public LessonData(TeacherRepository repository)
        {
            OnBindingTeacher = new MainCommand(
                _ => Teacher = new LessonLinkingToTeacherView(repository.Get()).InitializeComponents().Teacher);
        }
    }
}
