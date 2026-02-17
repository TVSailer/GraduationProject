using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorNotBelongingLessonButton(ControlView control, VisitorsLessonRepository repository) : 
    IButtons<ViewButtonClickArgs<VisitorNotBelongingLessonCardPanelUi>>, 
    IButtons<CardClickedArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<VisitorNotBelongingLessonCardPanelUi>? e)
        =>
        [
            new CustomButton("Назад")
                .CommandClick(() => control.Exit())
        ];

    public List<CustomButton> GetButtons(object? data, CardClickedArgs<VisitorEntity>? e)
        => [
            new CustomButton()
                .CommandClick(() =>
                {
                    repository.Add(e.Entity);
                    control.Exit();
                }),
        ];
}