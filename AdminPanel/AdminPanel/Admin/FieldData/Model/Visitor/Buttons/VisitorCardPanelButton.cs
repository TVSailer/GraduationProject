using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorNotBelongingLessonButton(ControlView control, MementoLesson repository) : 
    IButtons<ViewButtonClickArgs<VisitorNotBelongingLessonCardPanelUi>>, 
    IButton<CardClickedArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<VisitorNotBelongingLessonCardPanelUi>? e)
        =>
        [
            new CustomButton("Назад").CommandClick(control.Exit)
        ];

    public CustomButton GetButton(object? send, CardClickedArgs<VisitorEntity> eventArgs)
        => new CustomButton()
                .CommandClick(() =>
                {
                    repository.AddVisitor(eventArgs.Entity);
                    control.Exit();
                });
}