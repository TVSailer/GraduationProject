using Admin.DI;
using Admin.DI.Module;
using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Event.Buttons;

public class EventManagerClicked(
    ControlView controlView) : 
    IButtons<EventManager>,
    IButtons<CardClickedToolStripArgs<EventEntity>>, 
    IClicked<CardClickedArgs<EventEntity>>
{
    public List<InfoButton> GetButtons(CardClickedToolStripArgs<EventEntity> eventToolStripArgs)
        => [
        ];

    public List<InfoButton> GetButtons(EventManager eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить").CommandClick(() => controlView.LoadView<EventFieldData>()),
        ];

    public InfoButton GetButton(CardClickedArgs<EventEntity> eventArgs)
        => new InfoButton().CommandClick(() => controlView.LoadView<EventFieldData, EventEntity>(eventArgs.Entity));
}