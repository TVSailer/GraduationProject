using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Review.Buttons;

public class ReviewDetailsButton(
    MementoLesson repository,
    ControlView controlView) : 
    IButtons<ReviewFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<ReviewFieldData> e)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Удалить").CommandClick(() =>
            {
                if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                repository.DeleteReview(e.Data.EntityId);
                controlView.Exit();
            })
        ];
}