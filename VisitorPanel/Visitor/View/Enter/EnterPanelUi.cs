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
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
    => builderLayoutPanel.ObjectBinding(_dataUi).Column()
            .RowAbsolute(40).LabelTextBox("Логин", "Введите логин", nameof(EnterDataUi.Login))
            .RowAbsolute(40).LabelTextBox("Пароль", "Введите пароль", nameof(EnterDataUi.Password))
            .Row().End()
            .RowAbsolute(60)
                .Column(50).End()
                .Column(25).Content().Button(_buttons[0]).End()
                .Column(25).Content().Button("Выход").Click(Close).End()
            .End();
}