using Admin.DI.Module;
using Admin.FieldData.Model.Review;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.ViewModel.Model.Review.Buttons;

public class ReviewManagerButton(
    ControlView controlView,
    ReviewFieldData fieldData) 
    : IButtons<ReviewManager>,
        IButton<CardClickedArgs<ReviewEntity>>
{
    public List<CustomButton> GetButtons(ReviewManager eventArgs)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
        ];

    public CustomButton GetButton(CardClickedArgs<ReviewEntity> eventArgs)
        => new CustomButton().CommandClick(() =>
        {
            fieldData.Entity = eventArgs.Entity;
            controlView.LoadView<ReviewFieldData, ReviewEntity>(fieldData);
        });
}