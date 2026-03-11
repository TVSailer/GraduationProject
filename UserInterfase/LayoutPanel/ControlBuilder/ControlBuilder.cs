using System.Windows.Forms;

namespace UserInterface.LayoutPanel.ControlBuilder;

public abstract class ControlBuilder<TControl, TParentBuilder> : IControlBuilder<TControl, TParentBuilder>
    where TControl : Control, new()
{
    private readonly TParentBuilder _parentBuilder;
    protected readonly TControl Control;

    protected ControlBuilder(TParentBuilder parentBuilder)
    {
        _parentBuilder = parentBuilder;
        Control = SettingControl();
    }

    public abstract TControl SettingControl();

    public TControl Build() => Control;
    public TParentBuilder End() => _parentBuilder;
}