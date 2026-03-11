using System;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IButtons<in TEventArgs> 
{
    public List<CustomButton> GetButtons(TEventArgs eventArgs);
}

