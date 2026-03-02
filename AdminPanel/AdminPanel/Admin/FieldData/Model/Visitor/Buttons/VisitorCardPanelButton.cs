using Admin.DI.Module;
using Admin.View;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorNotBelongingLessonButton(ControlView control, MementoLesson repository) : 
    IButtons<VisitorNotBelongingLesson>, 
    IButton<CardClickedArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(VisitorNotBelongingLesson data)
        =>
        [
            new CustomButton("Назад").CommandClick(control.Exit)
        ];

    public CustomButton GetButton(CardClickedArgs<VisitorEntity> eventArgs)
        => new CustomButton()
                .CommandClick(() =>
                {
                    repository.AddOldVisitor(eventArgs.Entity);
                    control.Exit();
                });
}