namespace User_Interface_Library.UiLayoutPanel.ButtonPanel;

public interface IButtons<in TEventArgs>
{
    public List<CustomButton>? GetButtons(TEventArgs eventArgs);
}