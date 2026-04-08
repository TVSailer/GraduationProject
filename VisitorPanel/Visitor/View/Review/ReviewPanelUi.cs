using Domain.Enum;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;
using Visitor.ViewModel.Review;

namespace Visitor.View.Review;

public class ReviewPanelView(ReviewPanelViewModel viewModel) : Forma<ReviewPanelViewModel>
{
    public override void Initialize()
    {
        Size = new Size(width: 700, height: 500);
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
    {
        throw new NotImplementedException();
    }

    /*public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.ObjectBinding(_dataUi).Column()
            .RowAbsolute(40)
                .Column(10).Content().Label("Оценка: ").End()
                .Column(40).Content()
                    .ComboBox()
                    .SetData<Estimation>()
                    .Binding(_dataUi, nameof(ReviewDataUi.Estimation))
                .End()
                .Column(30, SizeType.Absolute).End()
            .End()
            .RowAbsolute(40).Content()
                .Label("Комментарий: ")
            .End()
            .Row().Content()
                .TextBox("Введите комментарий")
                .Binding(_dataUi, nameof(ReviewDataUi.Comment))
                .Multiline()
            .End()
            .Row().Content().ButtonLayoutPanel(_buttons.GetButtons(new ClickedArgs<ReviewDataUi>(_dataUi))).End();*/
}