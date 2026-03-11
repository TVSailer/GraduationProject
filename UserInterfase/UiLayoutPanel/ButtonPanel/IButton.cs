namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IButton<in TEventArgs>
    where TEventArgs : EventArgs
{
    public CustomButton GetButton(TEventArgs eventArgs);
}