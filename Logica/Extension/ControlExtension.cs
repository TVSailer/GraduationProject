using System.Collections;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Logica.Extension
{
    public static class ControlExtension
    {
        public static T Binding<T>(this T control, string propertyNameControl, object context, string nameMember) where T : Control
        {
            return control
                .With(c => 
                c.DataBindings.Add(propertyNameControl, context, nameMember, false, DataSourceUpdateMode.OnPropertyChanged));
        }

        public static T NewControl<T>(this T control, T newControl)
            => newControl;

    }
}

