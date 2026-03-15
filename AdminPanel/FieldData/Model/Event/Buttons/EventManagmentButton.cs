using Admin.DI.Module;
using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Event.Buttons;

public class EventManagerButtons(
    ControlView controlView) : 
    IButtons<EventManager>,
    IToolStrip<EventEntity>, 
    IClicked<EventEntity>
{
    public InfoToolStrip[] GetToolStrip(CardClickedToolStripArgs<EventEntity> eventToolStripArgs)
        => [
        ];

    public InfoButton[] GetButtons(ClickedArgs<EventManager> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить").CommandClick(() => controlView.LoadView<EventFieldData>()),
        ];

    public InfoButton GetButton(CardClickedArgs<EventEntity> eventArgs)
        => new InfoButton().CommandClick(() => controlView.LoadView<EventFieldData, EventEntity>(eventArgs.Entity));
}