using Logica;

public class ButtonPanel : IButtonPanel
{
    private readonly List<ButtonInfo> buttonInfos;
    private readonly object context;

    public ButtonPanel(List<ButtonInfo> buttonInfos, object context)
    {
        this.buttonInfos = buttonInfos;
        this.context = context;
    }

    public virtual Control? CreateButtonPanel()
        => FactoryElements.TableLayoutPanel()
        .With(t =>
        {
            for (int i = 0; i < buttonInfos.Count; i++)
            {
                if (i % 4 == 0 || i == 0)
                    t.ControlAddIsRowsAbsoluteV2(new TableLayoutPanel() { Dock = DockStyle.Fill}, 70);

                if (t.Controls[^1] is TableLayoutPanel table)
                    table.ControlAddIsColumnPercentV2(FactoryElements.Button(buttonInfos[i].Text, context, buttonInfos[i].DataMember));
            }

            if (t.Controls[^1].Controls.Count < 4)
                if (t.Controls[^1] is TableLayoutPanel table)
                    for (int i = table.Controls.Count; i < 4; i++)
                        table.ControlAddIsColumnPercentV2(FactoryElements.Button(""));
        });
}

