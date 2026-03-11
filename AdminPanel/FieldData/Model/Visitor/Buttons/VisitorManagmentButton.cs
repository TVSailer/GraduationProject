using Admin.DI.Module;
using DataAccess.PostgreSQL.Models;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorManagerButton(ControlView controlView) : 
    IButtons<VisitorManager>, 
    IButtons<CardClickedToolStripArgs<VisitorEntity>>, 
    IButton<CardClickedArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(VisitorManager eventArgs)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit)
        ];

    public List<CustomButton> GetButtons(CardClickedToolStripArgs<VisitorEntity> eventArgs)
        => [];

    public CustomButton GetButton(CardClickedArgs<VisitorEntity> eventArgs)
        => new CustomButton().CommandClick(() => controlView.LoadView<VisitorFieldData, VisitorEntity>(eventArgs.Entity));
}