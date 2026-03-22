using Admin.ViewModel.AbstractFieldData;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.ModelsPrimitive.Imgs;
using UserInterface.Attribute;
using Validaiger.AttributeValid;

namespace Admin.ViewModel.Model.Lesson;

public class LessonFieldData : FieldDataWithImages<ImgLessonEntity, LessonEntity>
{
    [LinkingEntity(nameof(LessonEntity.Imgs))]
    public List<ImgLessonEntity> Images { 
        get => ImagesData;
        set => ImagesData = value;
    }

    [RequiredCustom]
    [LinkingEntity("Name")]
    public string? Name { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity("Description")]
    public string? Description { get; set => ValidProperty(ref field, value); }

    [LinkingEntity("Schedule")]
    public List<LessonScheduleEntity>? Schedule
    {
        get;
        set
        {
            field = value;
            OnPropertyChange(nameof(ScheduleParse));
        }
    } = [];

    [RequiredCustom]
    public string? ScheduleParse => Schedule?.ParseSchedule();

    [RequiredCustom]
    [LinkingEntity("Location")]
    public string? Location { get; set => ValidProperty(ref field, value); }

    [MaxParticipants]
    [LinkingEntity("MaxParticipants")]
    public int MaxParticipants { get; set => ValidProperty(ref field, value); } = 1;

    [RequiredCustom]
    [LinkingEntity("Category")]
    public CategoryEntity? Category { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity("Teacher")]
    public TeacherEntity? Teacher { get; set => ValidProperty(ref field, value); }
}