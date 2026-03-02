using System.Windows.Forms;
using UserInterface.Message;

namespace UserInterface.LayoutPanel.ControlBuilder;

public static class MessageErrorProviderExtension
{
    private static readonly ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };

    public static Control ErrorProvider(this Control control, object dataSource, string dataMember)
    {

        if (dataSource is IMessageErrorProvider messageErrorProvider)
            messageErrorProvider.ErrorMassegeProvider += (_, e) =>
            {
                if (!dataMember.Equals(e.PropertyName)) return;
                errorProvider.SetError(control, e.ErrorMessage);
            };

        return control;
    }
}