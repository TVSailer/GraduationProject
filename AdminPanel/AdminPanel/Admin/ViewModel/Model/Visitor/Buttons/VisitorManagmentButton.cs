using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorManagmentButton(ControlView controlView) : 
    IButtons<ViewButtonClickArgs<VisitorManagment>>, IButtons<CardClickedToolStripArgs<VisitorEntity>>, IButton<CardClickedArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<VisitorManagment> eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit())
        ];

    public List<CustomButton>? GetButtons(object? data, CardClickedToolStripArgs<VisitorEntity>? eventArgs)
    {
        return null;
    }

    public CustomButton? GetButton(object? send, CardClickedArgs<VisitorEntity> eventArgs)
        => new CustomButton()
            .CommandClick(() => controlView.LoadView<VisitorDetailsFieldData, VisitorEntity>(eventArgs.Entity));
}