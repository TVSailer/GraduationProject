using DataAccess.PostgreSQL.Models;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.FieldData.Manager;

namespace Visitor.FieldData.Lesson.LessonButton;

public class ManagerLessonButton(ControlView controlView) : ManagerButton(controlView), IButton<CardClickedArgs<LessonEntity>>
{
    public CustomButton GetButton(CardClickedArgs<LessonEntity> eventArgs) 
        => new CustomButton().CommandClick(
            () => controlView.LoadView<LessonDataUi, LessonEntity>(eventArgs.Entity));
}