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

        public static Control OnErrorProvider(this Control control, string propertyName, object context)
        {
            if (context is not PropertyChange pc) return control;
            pc.ErrorMassegeProvider += (_, e) =>
            {
                if (!propertyName.Equals(e.PropertyName)) return;
                errorProvider.SetError(control, e.ErrorMessage);
            };

            return control;
        }
    }
}

