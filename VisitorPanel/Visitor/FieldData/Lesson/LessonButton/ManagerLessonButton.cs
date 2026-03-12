using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.FieldData.Manager;

namespace Visitor.FieldData.Lesson.LessonButton;

public class ManagerLessonClicked(ControlView controlView) : ManagerButton(controlView), IClicked<CardClickedArgs<LessonEntity>>
{
    public InfoButton GetButton(CardClickedArgs<LessonEntity> eventArgs) 
        => new InfoButton().CommandClick(
            () => controlView.LoadView<LessonDataUi, LessonEntity>(eventArgs.Entity));
}