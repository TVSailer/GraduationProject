using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;

namespace Visitor.View.Enter;

public class EnterPanelUi : Form
{
    public EnterPanelUi()
    {
        Size = new Size(width: 1100, height: 500);
        StartPosition = FormStartPosition.CenterScreen;

        Controls.Add(ControlUi().Build());
    }

    public IBuilder ControlUi()
        => new BuilderLayoutPanel().Column()
            .RowAutoSize().LabelTextBox("Логин", "Введите логин",)
            .RowAutoSize().LabelTextBox("Пароль", "Введите пароль",)
            .RowAbsolute(80)
                .Column(75).End()
                .Column(25).Content().Button().End()
            .End();
}