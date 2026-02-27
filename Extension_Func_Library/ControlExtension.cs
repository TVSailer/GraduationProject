using System.Windows.Forms;

namespace Extension_Func_Library
{
    public static class ControlExtension
    {
        private static ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };

        public static Control Binding(this Control control, string propertyNameControl, object context, string nameMember)
        {
            control.DataBindings.Add(propertyNameControl, context, nameMember, false, DataSourceUpdateMode.OnPropertyChanged);
            return control;
        }
        
        
        //public static Control OnErrorProvider<T>(this Control control, string propertyName, T context) where T : IMessageErrorProvider
        //{
        //    context.ErrorMassegeProvider += (_, e) =>
        //    {
        //        if (!propertyName.Equals(e.PropertyName)) return;
        //        errorProvider.SetError(control, e.ErrorMessage);
        //    };

        //    return control;
        //}

    }
}

