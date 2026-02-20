using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Event.Buttons;

public class EventManagmentButton(ControlView controlView) : 
    IButtons<ViewButtonClickArgs<EventManagment>>,
    IButtons<CardClickedToolStripArgs<EventEntity>>, 
    IButton<CardClickedArgs<EventEntity>>
{
    public List<CustomButton> GetButtons(object? data, CardClickedToolStripArgs<EventEntity> eventToolStripArgs)
        => [
        ];

    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<EventManagment> eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Добавить")
                .CommandClick(() => controlView.LoadView<EventAddingFieldData>()),
        ];

    public CustomButton? GetButton(object? send, CardClickedArgs<EventEntity> eventArgs)
        => new CustomButton()
            .CommandClick(() => controlView.LoadView<EventDetailsFieldData, EventEntity>(eventArgs.Entity));
}