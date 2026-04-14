using Domain.Service.ControlViewService.BaseControlView;
using UserInterface.Service.View.Base;

namespace General.Service.ControlView;

public class ControlViewService(IControlView controlView) : IControlViewService
{
    public void LoadView<T>() => controlView.LoadView<T>();
    public void UpdateGui() => controlView.UpdateGui();
    public void Exit() => controlView.Exit();
    public void ShowDialog<T>() => controlView.ShowDialog<T>();
    public void CloseDialog() => controlView.CloseDialog();
}