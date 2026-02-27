using System.Windows.Forms;

namespace User_Interface_Library.UiLayoutPanel.ButtonPanel;

public sealed class ButtonLayoutPanel : Panel
{
    private const int CountButtonsInOneTable = 4;

    public ButtonLayoutPanel(List<CustomButton>? button)
    {
        Dock = DockStyle.Fill;
        Initialize(button);
    }

    private void Initialize(List<CustomButton> button)
    {
        if (button.Count == 0) return;

        var index = 0;

        var column = LayerPanel.LayoutPanel.CreateColumn();
        var row = column.Row();

        for (; index < button.Count; index++)
            row.Column().ContentEnd(button[index]);

        if (index < 4)
            for (var i = index % CountButtonsInOneTable; i < CountButtonsInOneTable; i++)
                row.Column().ContentEnd(new CustomButton().NoEnabled());

        Controls.Add(column.Build());
    }
}