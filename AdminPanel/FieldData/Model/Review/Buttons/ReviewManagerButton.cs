using Admin.DI.Module;
using Admin.FieldData.Model.Review;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.ViewModel.Model.Review.Buttons;

public class ReviewManagerClicked(
    ControlView controlView,
    ReviewFieldData fieldData) 
    : IButtons<ReviewManager>,
        IClicked<CardClickedArgs<ReviewEntity>>
{
    public List<InfoButton> GetButtons(ReviewManager eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];

    public InfoButton GetButton(CardClickedArgs<ReviewEntity> eventArgs)
        => new InfoButton().CommandClick(() =>
        {
            fieldData.Entity = eventArgs.Entity;
            controlView.LoadView<ReviewFieldData, ReviewEntity>(fieldData);
        });
}