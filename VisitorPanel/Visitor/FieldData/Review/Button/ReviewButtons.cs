using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Visitor.FieldData.Review.Button;

public class ReviewButtons(ControlView controlView, MementoLesson repository) : IButtons<ReviewDataUi>
{
    public InfoButton[] GetButtons(ClickedArgs<ReviewDataUi> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.CloseShowDialog),
            new InfoButton("Добавить").CommandClick(() => eventArgs.Data.ValidObject((_, entity) => repository.AddReview(entity)))
        ];
}