using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Visitor.FieldData.Lesson.Button;

public class EventButton(ControlView controlView) : IButtons<ClickedArgs<EventEntity>>
{
    public InfoButton[] GetButtons(ClickedArgs<EventEntity> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}