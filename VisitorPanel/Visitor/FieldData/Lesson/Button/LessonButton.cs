using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Visitor.FieldData.Lesson.Button;

public class LessonButton(ControlView controlView, MementoVisitor mementoVisitor) : IButtons<LessonEntity>
{
    public InfoButton[] GetButtons(ClickedArgs<LessonEntity> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить отзыв").Enable(mementoVisitor.IsVisitor)
        ];
}