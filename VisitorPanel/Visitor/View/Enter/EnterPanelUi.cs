using UserInterface.Info;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.FieldData.Enter;
using Visitor.FieldData.Enter.Button;

namespace Visitor.View.Enter;

public class EnterPanelUi : Forma
{
    private readonly EnterDataUi _dataUi;
    private readonly InfoButton[] _buttons;

    public EnterPanelUi(EnterDataUi dataUi, EnterButtons buttons)
    {
        _dataUi = dataUi;
        _buttons = buttons.GetButtons(new ClickedArgs<EnterDataUi>(dataUi));
        Size = new Size(width: 500, height: 250);
        Controls.Add(ControlUi(new BuilderLayoutPanel()).Build());
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
    => builderLayoutPanel.ObjectBinding(_dataUi).Column()
            .RowAbsolute(40)
                .Column(10).Content().Label("Логин").End()
                .Column(40).Content().TextBox("Введите логин").Binding(_dataUi, nameof(EnterDataUi.Login)).End()
                .Column(30, SizeType.Absolute).End()
            .End()
            .RowAbsolute(40)
                .Column(10).Content().Label("Пароль").End()
                .Column(40).Content().TextBox("Введите пароль").UseSystemPasswordChar().Binding(_dataUi, nameof(EnterDataUi.Password)).End()
                .Column(30, SizeType.Absolute).End()
            .End()
            .Row().End()
            .RowAbsolute(50)
                .Column(50).End()
                .Column(25).Content().Button(_buttons[0]).End()
                .Column(25).Content().Button("Выход").Click(Close).End()
            .End();
}