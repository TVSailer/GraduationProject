using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Visitor.FieldData.Lesson.LessonButton;

public class LessonButton(ControlView controlView) : IClicked<CardClickedArgs<ReviewEntity>>, IButtons<ClickedArgs<LessonEntity>>
{
    public InfoButton GetButton(CardClickedArgs<ReviewEntity> eventArgs)
        => new InfoButton("Добавить отзыв");

    public InfoButton[] GetButtons(ClickedArgs<LessonEntity> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить отзыв").Enable()
        ];
}