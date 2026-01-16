using Admin.ViewModels.Lesson;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.View.Moduls.UIModel
{
    public class ButtonModule : IUIModel
    {
        private readonly IViewModele context;
        private readonly List<ButtonInfoUIAttribute> buttonsInfo = new();

        public ButtonModule(IViewModele context)
        {
            this.context = context;
            var buttonsInfo = context.GetType().GetAttributes<ButtonInfoUIAttribute>();

            if (buttonsInfo != null)
                this.buttonsInfo = buttonsInfo;
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

                if (t.Controls[^1].Controls.Count < 4)
                    if (t.Controls[^1] is TableLayoutPanel table)
                        for (int i = table.Controls.Count; i < 4; i++)
                            table.ControlAddIsColumnPercent(FactoryElements.Button(""));
            });
    }
}
