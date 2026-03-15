using Admin.DI.Module;
using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorManagerClicked(ControlView controlView) : 
    IButtons<VisitorManager>, 
    IToolStrip<VisitorEntity>, 
    IClicked<VisitorEntity>
{
    public InfoButton[] GetButtons(ClickedArgs<VisitorManager> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit)
        ];

    public InfoToolStrip[] GetToolStrip(CardClickedToolStripArgs<VisitorEntity> eventArgs)
        => [];

    public InfoButton GetButton(CardClickedArgs<VisitorEntity> eventArgs)
        => new InfoButton().CommandClick(() => controlView.LoadView<VisitorFieldData, VisitorEntity>(eventArgs.Entity));
}