using Admin.ViewModel.AbstractFieldData;
using Admin.ViewModel.GenericEntity;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Models.Imgs;
using User_Interface_Library.Attribute;
using User_Interface_Library.Interface;
using Validaiger.AttributeValid;

namespace Admin.ViewModel.Model.Lesson;

public class LessonFieldData : FieldData<LessonEntity>, IDataWithImgUi
{
    [LinkingEntity(nameof(LessonEntity.Imgs))]
    public List<ImgLessonEntity> Images { 
        get => RepositoryImgEntity.GetData().Select(i => new ImgLessonEntity(i)).ToList();
        set => RepositoryImgEntity.SetData(value.Select(i => i.Url).ToArray());
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
            OnPropertyChanged(nameof(ScheduleParse));
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

    public RepositoryImgEntity RepositoryImgEntity { get; set; } = new();
}