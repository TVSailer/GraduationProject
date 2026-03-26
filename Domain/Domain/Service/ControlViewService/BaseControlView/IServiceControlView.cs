namespace Domain.Service.ControlViewService.BaseControlView;

public interface IControlViewService
{
    public void LoadView<T>();
    public void UpdateGui();
    public void Exit();
    public void ShowDialog<T>();
    public void CloseDialog();
}