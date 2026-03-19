using DataAccess.PostgreSQL.Memento;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.View.Review;

namespace Visitor.FieldData.Lesson.Button;

public class LessonButton(ControlView controlView, MementoVisitor mementoVisitor) : IButtons<LessonDataUi>
{
    public InfoButton[] GetButtons(ClickedArgs<LessonDataUi> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить отзыв").Enable(mementoVisitor.IsVisitor && !eventArgs.Data.Entity.IsReviewVisitor(mementoVisitor.Visitor!)).CommandClick(controlView.ShowDialog<ReviewPanelUi>)
        ];
}