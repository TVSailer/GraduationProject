using DataAccess.PostgreSQL.ModelsPrimitive;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Visitor.FieldData.Event.Button;

public class EventButton(ControlView controlView) : IButtons<EventEntity>
{
    public InfoButton[] GetButtons(ClickedArgs<EventEntity> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}