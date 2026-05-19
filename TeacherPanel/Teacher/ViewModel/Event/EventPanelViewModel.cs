using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Entitys.ComplexType;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.SharedService.BaseSharedService;

namespace Teacher.ViewModel.Event;

public class EventPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IImageFileService _imageFileService;
    private readonly EventEntity _event;

    #region Property

    public string Title => _event.Title;
    public CategoryEntity Category => _event.Category;
    public string Location => _event.Location;
    public string Organizer => _event.Organizer;
    public EventEntitySchedule Schedule => _event.Schedule;
    public string Description => _event.Description;
    public IEnumerable<string>? Images => _event.GetImages().Select(i => _imageFileService.GetFullPath(i));

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
        IImageFileService imageFileService,
        ISharedService sharedService
        )
    {
        _controlViewService = controlViewService;
        _imageFileService = imageFileService;
        _event = sharedService.GetData<EventEntity>();

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        OpenLinkRegistration = new ExecuteCommand(ExecuteOpenLinkRegistration, CanExecuteOpenLinkRegistration);
    }
}