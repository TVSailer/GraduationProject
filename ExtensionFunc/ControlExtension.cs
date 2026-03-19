using System.Windows.Forms;

namespace ExtensionFunc
{
    public static class ControlExtension
    {

        public static Control Binding(this Control control, string propertyNameControl, object context, string nameMember)
        {
            control.DataBindings.Add(propertyNameControl, context, nameMember, false, DataSourceUpdateMode.OnPropertyChanged);
            return control;
        }

    }
}

