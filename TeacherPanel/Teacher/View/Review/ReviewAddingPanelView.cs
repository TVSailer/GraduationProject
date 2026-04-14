using Teacher.ViewModel.Review;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Teacher.View.Review;

public class ReviewAddingPanelView(ReviewAddingPanelViewModel viewModel) : Forma<ReviewAddingPanelViewModel>
{
    public override void Initialize()
    {
        Size = new Size(width: 700, height: 500);
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .RowAbsolute(40)
                .Column(10).Content()
                    .Label("Оценка: ")
                .End()
                .Column(40).Content()
                    .ComboBox()
                    .SetData(viewModel.Estimations)
                    .Binding(viewModel, nameof(viewModel.Estimation))
                .End()
                .Column(30, SizeType.Absolute).End()
            .End()
            .RowAbsolute(40).Content()
                .Label("Комментарий: ")
            .End()
            .Row()
                .Column(97).Content()
                    .TextBox("Введите комментарий")
                    .Binding(viewModel, nameof(viewModel.Comment))
                    .Multiline()
                .End()
                .Column(3)
                .End()
            .End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column()
                .End()
                .Column().Content()
                    .Button("Добавить")
                    .Command(viewModel.AddComment)
                .End()
            .End();
}