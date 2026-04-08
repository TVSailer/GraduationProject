using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Entitys.ComplexType;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;

namespace Visitor.ViewModel.Event;

public class EventPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;

    #region Property

    public string Title { get; set; }
    public CategoryEntity Category { get; set; }
    public string Location { get; set; }
    public string Organizer { get; set; }
    public EventEntitySchedule Schedule { get; set; }
    public string Description { get; set; }
    public IEnumerable<string>? Images { get; set; }

    #endregion
    #region CommandOpenLinkRegistration

    internal readonly ICommand OpenLinkRegistration;

    private void ExecuteOpenLinkRegistration(object? obj)
    {

    }

    private bool CanExecuteOpenLinkRegistration(object? obj) => true;

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public EventPanelViewModel(
        IControlViewService controlViewService,
        ISharedService sharedService
        )
    {
        _controlViewService = controlViewService;

        var entity = sharedService.GetData<EventEntity>();

        Title = entity.Title;
        Category = entity.Category;
        Location = entity.Location;
        Organizer = entity.Organizer;
        Schedule = entity.Schedule;
        Description = entity.Description;
        Images = entity.GetImages();

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        OpenLinkRegistration = new ExecuteCommand(ExecuteOpenLinkRegistration, CanExecuteOpenLinkRegistration);
    }
}