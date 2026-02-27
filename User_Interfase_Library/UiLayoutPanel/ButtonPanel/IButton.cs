namespace User_Interface_Library.UiLayoutPanel.ButtonPanel;

public interface IButton<in TEventArgs>
{
    public CustomButton? GetButton(TEventArgs eventArgs);
}