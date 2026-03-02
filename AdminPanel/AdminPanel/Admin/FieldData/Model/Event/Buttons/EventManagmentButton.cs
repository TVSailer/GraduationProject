using Admin.DI;
using Admin.DI.Module;
using DataAccess.Postgres.Models;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Event.Buttons;

public class EventManagerButton(
    ControlView controlView) : 
    IButtons<EventManager>,
    IButtons<CardClickedToolStripArgs<EventEntity>>, 
    IButton<CardClickedArgs<EventEntity>>
{
    public List<CustomButton> GetButtons(CardClickedToolStripArgs<EventEntity> eventToolStripArgs)
        => [
        ];

    public List<CustomButton> GetButtons(EventManager eventArgs)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Добавить").CommandClick(() => controlView.LoadView<EventFieldData>()),
        ];

    public CustomButton GetButton(CardClickedArgs<EventEntity> eventArgs)
        => new CustomButton().CommandClick(() => controlView.LoadView<EventFieldData, EventEntity>(eventArgs.Entity));
}