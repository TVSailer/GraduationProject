using Admin.ViewModel.Managment;
using Logica;
using Logica.UILayerPanel;
using Ninject.Activation;

namespace Admin.View.Moduls.UIModel;

public class ButtonModuleV2(List<ButtonInfo> button) : IUIModel
{
    public Control CreateControl()
        => FactoryElements.TableLayoutPanel()
            .With(t =>
            {
                if (button.Count == 0) return;

                for (int i = 0; i < button.Count; i++)
                {
                    if (i % 4 == 0 || i == 0)
                        t.ControlAddIsRowsAbsolute(new TableLayoutPanel() { Dock = DockStyle.Fill }, 70);

                    if (t.Controls[^1] is TableLayoutPanel table)
                        table.ControlAddIsColumnPercent(FactoryElements.Button(button[i].LabelText, button[i].Command, button[i].Enabled));
                }

                if (t.Controls[^1].Controls.Count >= 4) return;
                {
                    if (t.Controls[^1] is not TableLayoutPanel table) return;
                    for (int i = table.Controls.Count; i < 4; i++)
                        table.ControlAddIsColumnPercent(FactoryElements.Button(""));
                }
            });
}