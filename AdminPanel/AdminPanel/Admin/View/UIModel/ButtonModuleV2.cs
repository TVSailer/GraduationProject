using Admin.ViewModel.Managment;
using Logica;
using Logica.Interface;
using Logica.UI;

namespace Admin.View.Moduls.UIModel;

public sealed class ButtonLayoutPanel<TEventArgs> : TableLayoutPanel
{
    private object? _send;
    private TEventArgs? _eventArgs;

    public ButtonLayoutPanel()
    {
        Dock = DockStyle.Fill;
    }

    public ButtonLayoutPanel<TEventArgs> SetClickedData(object? send, TEventArgs eventArgs) => this.With(_ => _send = send).With(_ => _eventArgs = eventArgs);
    public ButtonLayoutPanel<TEventArgs> SetButtons(IButtons<TEventArgs> buttons) => this.With(_ => Initialize(buttons.GetButtons(_send, _eventArgs)));

    private void Initialize(List<CustomButton> button)
    {
        if (button.Count == 0) return;

        for (int i = 0; i < button.Count; i++)
        {
            if (i % 4 == 0 || i == 0)
                this.ControlAddIsRowsAbsolute(new TableLayoutPanel { Dock = DockStyle.Fill }, 70);

            if (Controls[^1] is TableLayoutPanel table)
                table.ControlAddIsColumnPercent(button[i]);
        }

        if (Controls[^1].Controls.Count >= 4) return;
        {
            if (Controls[^1] is not TableLayoutPanel table) return;
            for (int i = table.Controls.Count; i < 4; i++)
                table.ControlAddIsColumnPercent(new CustomButton().NoEnabled());
        }
    }
}