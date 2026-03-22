using Domain.Command;
using Domain.Repository;
using System.Windows.Input;
using Domain.Entitys;
using Domain.Entitys.ComplexType;
using Domain.Entitys.ImagesEntity;
using Domain.Valid.AttributeValid;

namespace Admin.FieldData.Model.Event;

public class EventViewModel : Abstract.ViewModel.ViewModel
{
    private readonly IRepository<EventEntity> _repositoryE;

    [Title] public string? Title { get; set => Set(ref field, value); }
    [Image] public string? TitleImg { get; set => Set(ref field, value); }
    [Description] public string? Description { get; set => Set(ref field, value); }
    [Date] public string? Date { get; set => Set(ref field, value); } = DateTime.Now.ToShortDateString();
    [Time] public string? TimeStart { get; set => Set(ref field, value); } = "10:00";
    [Time] public string? TimeEnd { get; set => Set(ref field, value); } = "12:00";
    [Location] public string? Location { get; set => Set(ref field, value); }
    [Organizer] public string? Organizer { get; set => Set(ref field, value); }
    [RequiredCustom] public CategoryEntity? Category { get; set => Set(ref field, value); }
    [Url] public string? RegisLink { get; set => Set(ref field, value); }
    [Schedule] public EventSchedule Schedule
    {
        get => new (TimeStart, TimeEnd, Date);
        set
        {
            TimeStart = value.Start;
            TimeEnd = value.End;
            Date = value.Date;
        }
    }

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

