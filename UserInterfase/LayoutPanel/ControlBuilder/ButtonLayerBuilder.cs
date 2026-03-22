using System.Windows.Forms;
using System.Windows.Input;
using UserInterface.Command;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ButtonLayerBuilder<TParentBuilder> : ControlBuilder<Panel, TParentBuilder>
{
    private const int CountButtonsInOneTable = 4;

    internal ButtonLayerBuilder<TParentBuilder> Data(ICommand[] button)
    {
        if (button.Length == 0 && button.Length > 4) return this;

        var index = 0;

        var column = new BuilderLayoutPanel().Column();
        var row = column.Row();

        for (; index < button.Length; index++)
            row.Column()
                .Content()
                .Button()
                .Command(button[index])
                .End();

        if (index < 4)
            for (var i = index % CountButtonsInOneTable; i < CountButtonsInOneTable; i++)
                row.Column()
                    .Content()
                    .Button()
                    .NoEnable();

        Control.Controls.Add(column.Build());

        return this;
    }

    protected override Panel SettingControl()
    {
        return new Panel() { Dock = DockStyle.Fill };
    }
}