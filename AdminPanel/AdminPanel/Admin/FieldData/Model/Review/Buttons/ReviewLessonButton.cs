using Admin.FieldData.Model.Review;
using DataAccess.Postgres.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.ViewModel.Model.Review.Buttons;

public class ReviewDetailsButton(
    Repository<ReviewEntity> repository,
    ControlView controlView) : 
    IButtons<ReviewFieldData>
{
    public List<CustomButton> GetButtons(ReviewFieldData e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Удалить").CommandClick(() =>
            {
                repository.Delete(e.EntityId);
                controlView.Exit();
            })
        ];
}