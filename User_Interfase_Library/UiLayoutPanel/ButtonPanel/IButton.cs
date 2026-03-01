namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IButton<in TEventArgs>
{
    public CustomButton GetButton(TEventArgs eventArgs);
}