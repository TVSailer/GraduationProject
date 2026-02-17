using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Managment;

public class ManagmentVisitorButton(ControlView controlView) : 
    IButtons<ViewButtonClickArgs<VisitorManagment>>, IButtons<CardClickedArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<VisitorManagment> eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit())
        ];

    public List<CustomButton>? GetButtons(object? data, CardClickedArgs<VisitorEntity>? eventArgs)
    {
        return null;
    }
}