using Admin.ViewModel.Model.Review;
using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Admin.View.Moduls.Review;

public class ReviewsManagerPanelView(ReviewManagerViewModel viewModel) : UiView<ReviewManagerViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
                .CardFlowLayoutPanel<ReviewEntity, ReviewCard>()
                .ClickedCard(viewModel.LoadDetailsPanel)
                .Binding(viewModel, nameof(viewModel.ReviewEntities))
            .End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
                .End()
            .End();
}