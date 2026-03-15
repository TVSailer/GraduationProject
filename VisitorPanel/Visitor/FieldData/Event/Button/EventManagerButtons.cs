using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.DI.Module;

namespace Visitor.FieldData.Event.Button;

public class EventManagerButtons(ControlView controlView) :  
    IClicked<CardClickedArgs<EventEntity>>,
    IButtons<ClickedArgs<EventManager>>
{
    public InfoButton GetButton(CardClickedArgs<EventEntity> eventArgs) 
        => new InfoButton().CommandClick(
            () => controlView.LoadView<EventDataUi, EventEntity>(eventArgs.Entity));

    public InfoButton[] GetButtons(ClickedArgs<EventManager> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(controlView.UpdateGUI)
        ];
}