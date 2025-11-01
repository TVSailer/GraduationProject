using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Xml.Linq;

namespace Logica.Extension
{
    public static class ControlExtension
    {
        public static T With<T>(this T control, Action<T> action) where T : Control
        {
            action?.Invoke(control);
            return control;
        }
        
        public static T ForEach<T>(this T control, Action<T> action, List<T> list)
        {
            foreach (var item in list)
                action?.Invoke(item);

            return control;
        }

        public static T TryDo<T>(this T control, Action<T> action, bool isTry) where T : Control
            => isTry ? control.With(action) : control;

        public static ButtonBase Button<T>(this T control, string text)
            => new Button()
                .With(c => c.Text = text)
                .With(c => c.Dock = DockStyle.Fill)
                .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold))
                .With(c => c.BackColor = SystemColors.ButtonFace)
                .With(c => c.ForeColor = SystemColors.ControlText);
    }


}
