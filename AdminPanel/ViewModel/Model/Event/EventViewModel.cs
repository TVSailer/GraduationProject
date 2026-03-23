using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Entitys.ComplexType;
using Domain.Entitys.ImagesEntity;
using Domain.Repository;
using Domain.Valid.AttributeValid;

namespace Admin.ViewModel.Model.Event;

public class EventViewModel : Abstract.ViewModel.ViewModel
{
    private readonly IRepository<EventEntity> _repositoryE;

    [Title] public string? Title { get; set => Set(ref field, value); }
    [Image] public string? TitleImg { get; set => Set(ref field, value); }
    [Description] public string? Description { get; set => Set(ref field, value); }
    [Date] public string? Date { get; set => Set(ref field, value); } = DateTime.Now.ToShortDateString();
    [Time] public string? TimeStart
    {
        get;
        set
        {
            Set(ref field, value);
            ValidProperty(Schedule, nameof(Schedule));
        }
    } = "10:00";
    [Time] public string? TimeEnd
    {
        get;
        set
        {
            Set(ref field, value);
            ValidProperty(Schedule, nameof(Schedule));
        }
    } = "12:00";
    [Location] public string? Location { get; set => Set(ref field, value); }
    [Organizer] public string? Organizer { get; set => Set(ref field, value); }
    [RequiredCustom] public CategoryEntity? Category { get; set => Set(ref field, value); }
    [Url] public string? RegisLink { get; set => Set(ref field, value); }
    [ScheduleEntity] public EventEntitySchedule Schedule => new (TimeStart, TimeEnd, Date);
    public ICollection<ImageEventEntity> Images { get; set; } = [];

    #region CommandSave

    internal readonly ICommand Save;

    private void ExecuteSave(object? obj)
    {
        _repositoryE.Add(
            new EventEntity(
                Title, TitleImg, Description, Location, RegisLink, Organizer, Schedule, Category, Images)
            );
    }

    private bool CanExecuteSave(object? obj) => ValidObject();

    #endregion

    public EventViewModel(IRepository<EventEntity> repositoryE)
    {
        _repositoryE = repositoryE;
        Save = new ExecuteCommand(ExecuteSave, CanExecuteSave);
    }
}

