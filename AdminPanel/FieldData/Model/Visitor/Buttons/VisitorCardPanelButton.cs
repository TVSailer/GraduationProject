using Admin.DI.Module;
using Admin.View;
using DataAccess.Postgres;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorNotBelongingLessonClicked(ControlView control, MementoLesson repository) : 
    IButtons<VisitorNotBelongingLesson>, 
    IClicked<CardClickedArgs<VisitorEntity>>
{
    public List<InfoButton> GetButtons(VisitorNotBelongingLesson data)
        =>
        [
            new InfoButton("Назад").CommandClick(control.Exit)
        ];

    public InfoButton GetButton(CardClickedArgs<VisitorEntity> eventArgs)
        => new InfoButton()
                .CommandClick(() =>
                {
                    repository.AddOldVisitor(eventArgs.Entity);
                    control.Exit();
                });
}