using Admin.ViewModel.Managment;
using Logica;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel;

public class ButtonModuleV2 : IUIModel
{
    private readonly List<ButtonInfo> context;

    public ButtonModuleV2(IParametersButtons context)
    {
        this.context = context.buttons;
    }

    public Control CreateControl()
        => FactoryElements.TableLayoutPanel()
            .With(t =>
            {
                if (context.Count == 0) return;

                for (int i = 0; i < context.Count; i++)
                {
                    if (i % 4 == 0 || i == 0)
                        t.ControlAddIsRowsAbsolute(new TableLayoutPanel() { Dock = DockStyle.Fill }, 70);

                    if (t.Controls[^1] is TableLayoutPanel table)
                        table.ControlAddIsColumnPercent(FactoryElements.Button(context[i].LabelText, context[i].Command));
                }

                if (t.Controls[^1].Controls.Count >= 4) return;
                {
                    if (t.Controls[^1] is not TableLayoutPanel table) return;
                    for (int i = table.Controls.Count; i < 4; i++)
                        table.ControlAddIsColumnPercent(FactoryElements.Button(""));
                }
            });
}