using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Visitor.FieldData.Visitor.Button;

public class VisitorButtons(ControlView controlView) : IButtons<VisitorEntity>
{
    public InfoButton[] GetButtons(ClickedArgs<VisitorEntity> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}