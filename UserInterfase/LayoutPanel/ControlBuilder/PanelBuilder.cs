using System.Windows.Forms;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class PanelBuilder<TParentBuilder> : ControlBuilder<Panel, TParentBuilder>
{
    public PanelBuilder<TParentBuilder> Contents(Func<BuilderLayoutPanel, IBuilder> build)
    {
        Control.Controls.Add(build.Invoke(new BuilderLayoutPanel()).Build());
        return this;
    }

    protected override Panel SettingControl()
        => new()
        {
            BorderStyle = BorderStyle.FixedSingle,
            Dock = DockStyle.Fill
        };
}