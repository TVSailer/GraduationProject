using Admin.FieldData.Model.Review;
using Admin.FieldData.Model.Review.Buttons;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.View.Moduls.Review;

public class ReviewPanelUi(ReviewDetailsButton button) : UiView<ReviewFieldData, ReviewEntity>
{
    private const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.ObjectBinding(DataUi).Column()
            .Row()
                .Column()
                    .Row(SizeRow).LabelTextBoxReadOnly("Рейтинг: ", "", nameof(ReviewFieldData.Rating))
                    .Row(SizeRow).LabelTextBoxReadOnly("Автор: ", "", nameof(ReviewFieldData.Visitor))
                    .Row(200, SizeType.Absolute).LabelTextBoxReadOnlyMultiline("Комментарий: ", "", nameof(ReviewFieldData.Comment))
                    .Row().End()
                .End()
                .Column().End()
            .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(button.GetButtons(new ClickedArgs<ReviewFieldData>(DataUi))).End();

}