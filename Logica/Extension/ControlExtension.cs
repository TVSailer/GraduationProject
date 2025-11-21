using System.Collections;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Logica.Extension
{
    public static class ControlExtension
    {
       
        public static T NewControl<T>(this T control, T newControl)
            => newControl;

    }
}

