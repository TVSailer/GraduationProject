using Admin.View.ViewForm;
using Admin.ViewModels.Lesson;
using Logica;

namespace Admin.View.Moduls.UIModel
{
    public class ButtonModule : IUIModel
    {
        private readonly IViewModele context;
        private readonly List<ButtonInfoUIAttribute> buttonsInfo = new();

        public ButtonModule(IViewModele context)
        {
            this.context = context;
            buttonsInfo = context.GetType().GetAttributes<ButtonInfoUIAttribute>();
        }

        public Control CreateControl()
        => FactoryElements.TableLayoutPanel()
            .With(t =>
            {
                for (int i = 0; i < buttonsInfo.Count; i++)
                {
                    if (i % 4 == 0 || i == 0)
                        t.ControlAddIsRowsAbsolute(new TableLayoutPanel() { Dock = DockStyle.Fill }, 70);

                    if (t.Controls[^1] is TableLayoutPanel table)
                        table.ControlAddIsColumnPercent(FactoryElements.Button(buttonsInfo[i], context));
                }

                if (t.Controls[^1].Controls.Count >= 4) return;
                {
                    if (t.Controls[^1] is not TableLayoutPanel table) return;
                    for (int i = table.Controls.Count; i < 4; i++)
                        table.ControlAddIsColumnPercent(FactoryElements.Button(""));
                }
            });

    }
}
