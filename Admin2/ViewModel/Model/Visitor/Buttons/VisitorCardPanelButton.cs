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
    List<CustomButton<ViewButtonClickArgs<VisitorNotBelongingLessonCardPanelUi>>> IButtons<ViewButtonClickArgs<VisitorNotBelongingLessonCardPanelUi>>.GetButtons(object? data = null)
        =>
        [
            new CustomButton<ViewButtonClickArgs<VisitorNotBelongingLessonCardPanelUi>>()
                .LabelText("Назад")
                .CommandClick((_, _) => control.Exit())
        ];

    List<CustomButton<CardClickedArgs<VisitorEntity>>> IButtons<CardClickedArgs<VisitorEntity>>.GetButtons(object? data)
        => [
            new CustomButton<CardClickedArgs<VisitorEntity>>()
                .CommandClick((s, e) =>
                {
                    repository.Add(e.Entity);
                    control.Exit();
                }),
        ];
}