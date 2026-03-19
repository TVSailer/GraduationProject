using DataAccess.PostgreSQL.Enum;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.FieldData.Review;
using Visitor.FieldData.Review.Button;

namespace Visitor.View.Review;

public class ReviewPanelUi : Forma
{
    private readonly ReviewDataUi _dataUi;
    private readonly ReviewButtons _buttons;

    public ReviewPanelUi(ReviewDataUi dataUi, ReviewButtons buttons)
    {
        _dataUi = dataUi;
        _buttons = buttons;
        Size = new Size(width: 700, height: 500);
        Controls.Add(ControlUi(new BuilderLayoutPanel()).Build());
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
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
            .Row().Content().ButtonLayoutPanel(_buttons.GetButtons(new ClickedArgs<ReviewDataUi>(_dataUi))).End();
}