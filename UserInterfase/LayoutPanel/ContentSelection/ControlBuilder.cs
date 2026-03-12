using System.Windows.Forms;

namespace UserInterface.LayoutPanel.ControlBuilder;

public abstract class ControlBuilder<TControl, TParentBuilder> : IControlBuilder<TControl, TParentBuilder>
    where TControl : Control, new()
{
    private TParentBuilder? _parentBuilder;
    protected TControl? Control;

    public ControlBuilder<TControl, TParentBuilder> Initialize(TParentBuilder parentBuilder)
    {
        _parentBuilder = parentBuilder;
        Control = SettingControl();
        return this;
    }

    protected abstract TControl SettingControl();

    public TControl Build() => Control ?? throw new ArgumentNullException();
    public TParentBuilder End() => _parentBuilder ?? throw new ArgumentNullException();
}