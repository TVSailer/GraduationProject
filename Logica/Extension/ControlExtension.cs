using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Xml.Linq;

namespace Logica.Extension
{
    public static class ControlExtension
    {
        public static T With<T>(this T control, Action<T> action) where T : class
        {
            action?.Invoke(control);
            return control;
        }
        
        public static T ForEach<T>(this T control, Action<T> action, List<T> list)
        {
            list.ForEach(l => action?.Invoke(l));
            return control;
        }

        public static ButtonBase Button<T>(this T control, string text)
            => new Button()
                .With(c => c.Text = text)
                .With(c => c.Dock = DockStyle.Fill)
                .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold))
                .With(c => c.BackColor = SystemColors.ButtonFace)
                .With(c => c.ForeColor = SystemColors.ControlText);

        public static ButtonBase Button<T>(this T control, string text, Action action)
            => new Button()
                .With(c => c.Text = text)
                .With(c => c.Dock = DockStyle.Fill)
                .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold))
                .With(c => c.BackColor = SystemColors.ButtonFace)
                .With(c => c.ForeColor = SystemColors.ControlText)
                .With(c => c.Click += (s, e) => action?.Invoke());

        public static Label LabelTitle<T>(this T control, string text)
            => new Label()
                .Label(text)
                .With(l => l.Font = new Font("Times New Roman", 18, FontStyle.Bold))
                .With(l => l.TextAlign = ContentAlignment.TopCenter);

        public static Label LabelHeard<T>(this T control, string text)
            => new Label()
                .Label(text)
                .With(l => l.Font = new Font("Times New Roman", 11, FontStyle.Bold));
        public static Label LabelMini<T>(this T control, string text)
            => new Label()
                .Label(text)
                .With(l => l.Font = new Font("Times New Roman", 9, FontStyle.Bold));
        
        public static Label Label<T>(this T control, string text)
            => new Label()
                .With(l => l.Name = text.Replace(" ", "") + "Label")
                .With(l => l.Text = text)
                .With(l => l.Dock = DockStyle.Fill)
                .With(l => l.TextAlign = ContentAlignment.TopLeft)
                .With(l => l.BorderStyle = BorderStyle.None)
                .With(l => l.Padding = new Padding(5));

    }


}
