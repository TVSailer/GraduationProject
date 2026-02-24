using Logica.Massage;
using Logica.Message;

namespace Logica.Extension
{
    public static class ControlExtension
    {
        private static ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };

        public static Control Binding(this Control control, string propertyNameControl, object context, string nameMember)
        {
            return control
                .With(c => 
                c.DataBindings.Add(propertyNameControl, context, nameMember, false, DataSourceUpdateMode.OnPropertyChanged));
        }

        public static Control OnErrorProvider<T>(this Control control, string propertyName, T context) where T : IMessageErrorProvider
        {
            context.ErrorMassegeProvider += (_, e) =>
            {
                if (!propertyName.Equals(e.PropertyName)) return;
                errorProvider.SetError(control, e.ErrorMessage);
            };

            return control;
        }
    }
}

