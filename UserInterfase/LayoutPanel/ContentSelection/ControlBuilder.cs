using System.Windows.Forms;
using UserInterface.Message.ErrorMessage;

namespace UserInterface.LayoutPanel.ContentSelection;

public abstract class ControlBuilder<TControl, TParentBuilder> : IControlBuilder<TControl, TParentBuilder>
    where TControl : Control, new()
{
    private readonly ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
    private TParentBuilder? _parentBuilder;
    protected TControl? Control;

    internal ControlBuilder<TControl, TParentBuilder> Initialize(TParentBuilder parentBuilder)
    {
        _parentBuilder = parentBuilder;
        Control = SettingControl();
        return this;
    }

    protected virtual TControl SettingControl() => new();
    public virtual TControl Build() => Control;
    public virtual TParentBuilder End() => _parentBuilder ?? throw new ArgumentNullException();

    protected TControl ErrorProvider(object dataSource, string dataMember)
    {
        if (dataSource is IMessageErrorProvider messageErrorProvider)
        {
            messageErrorProvider.ErrorMassegeProvider += (_, e) =>
            {
                if (!dataMember.Equals(e.PropertyName)) return;
                errorProvider.SetError(Control, e.ErrorMessage);
            };
        }
        return Control;
    }
}