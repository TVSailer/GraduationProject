using System.Windows.Forms;
using UserInterface.Info;
using UserInterface.LayoutPanel;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public sealed class ButtonLayoutPanel : Panel
{
    private const int CountButtonsInOneTable = 4;

    public ButtonLayoutPanel(List<InfoButton> button)
    {
        Dock = DockStyle.Fill;
        Initialize(button);
    }

    private void Initialize(List<InfoButton> button)
    {
        if (button.Count == 0 && button.Count > 4) return;

        var index = 0;

        var column = new BuilderLayoutPanel().Column();
        var row = column.Row();

        for (; index < button.Count; index++)
            row.Column()
                .Content()
                .Button()
                .InfoButton(button[index])
                .End();

        if (index < 4)
            for (var i = index % CountButtonsInOneTable; i < CountButtonsInOneTable; i++)
                row.Column()
                    .Content()
                    .Button()
                    .Enable(false);

        Controls.Add(column.Build());
    }
}