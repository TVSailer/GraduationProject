using Admin.ViewModel.AbstractViewModel;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.CustomAttribute;
using NotNullAttribute = Logica.CustomAttribute.NotNullAttribute;

namespace Admin.ViewModels.Lesson;

public class LessonFieldData(
    TeacherRepository teacherRepository,
    LessonCategoryRepositroy eventCategoryRepository)
    : FieldModelWithImages<LessonEntity>
{
    public List<LessonCategoryEntity> Categories => eventCategoryRepository.Get();
    public List<TeacherEntity> teachers => teacherRepository.Get();

    [RequiredCustom]
    [LinkingEntity("Name")]
    [BaseFieldUi("Название:*", "Введите название")]
    public string? Name { get; set => TryValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity("Description")]
    [MultilineFieldUi]
    public string? Description { get; set => TryValidProperty(ref field, value); }

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

    [RequiredCustom]
    [ReadOnlyFieldUi("Расписание*:", "Создайте расписание")]
    public string? ScheduleParse => Schedule?.ParseSchedule();

    [RequiredCustom]
    [LinkingEntity("Location")]
    [BaseFieldUi("Место проведения:*", "Введите место проведения")]
    public string? Location { get; set => TryValidProperty(ref field, value); }

    [MaxParticipants]
    [LinkingEntity("MaxParticipants")]
    [NumericFieldUi("Кол. участников:*")]
    public int MaxParticipants { get; set => TryValidProperty(ref field, value); } = 1;

    [RequiredCustom]
    [LinkingEntity("Category")]
    [ComboBoxFieldUi("Категория:*", nameof(Categories))]
    public LessonCategoryEntity? Category { get; set => TryValidProperty(ref field, value); }

    [NotNull]
    [LinkingEntity("Teacher")]
    [ComboBoxFieldUi("Преподователь:*", nameof(teachers))]
    public TeacherEntity? Teacher { get; set => TryValidProperty(ref field, value); }
}