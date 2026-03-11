using DataAccess.PostgreSQL.Repository;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Review.Buttons;

public class ReviewDetailsButton(
    MementoLesson repository,
    ControlView controlView) : 
    IButtons<ReviewFieldData>
{
    public List<CustomButton> GetButtons(ReviewFieldData e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Удалить").CommandClick(() =>
            {
                if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                repository.DeleteReview(e.EntityId);
                controlView.Exit();
            })
        ];
}