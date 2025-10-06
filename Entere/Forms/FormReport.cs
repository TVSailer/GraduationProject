using Entere.Presents;
using Logica;
using System.ComponentModel;

namespace Entere.Forms
{
    class FormReport : Form
    {
        private const int WIDHT = 700;
        private const int HEINGT = 260;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BaseCreatingElements CreatingElements { get; set; }

        public FormReport(EnterPresent present)
        {
            CreatingElements = new CreatingElements(new Style());

            var listLabel = CreatingElements.CreateListLabel(
                Attributes.InputLogin,
                Attributes.InputPassford,
                Attributes.RepeatPassvord);

            List<TextBox> listTextBox = new();

            var textBox1 = CreatingElements.CreateTextBox(Attributes.InputLogin);
            textBox1.TextChanged += (send, e)
                => present.Login = textBox1.Text;
            listTextBox.Add(textBox1);

            var textBox2 = CreatingElements.CreateTextBox(Attributes.InputPassford);
            textBox2.TextChanged += (send, e)
                => present.Password = textBox2.Text;
            listTextBox.Add(textBox2);
            
            var textBox3 = CreatingElements.CreateTextBox(Attributes.RepeatPassvord);
            textBox3.TextChanged += (send, e)
                => present.RepeatPassword = textBox3.Text;
            listTextBox.Add(textBox3);

            var buttonComplete = CreatingElements.CreateButton(Attributes.Complete);
            buttonComplete.Click += (send, e) => Close();
            
            var buttonReport = CreatingElements.CreateButton(Attributes.Report);
            buttonReport.Click += (send, e) => present.OnAddAdmin();
            buttonReport.Click += (send, e) => Close();

            var table = CreatingElements.CreateTableLayoutPanel(3, 40, 40, 40, 40)
                .ControlsAddByColumnOrRow(listLabel, 0, 1, false)
                .ControlsAddByColumnOrRow(listTextBox, 1, 1, false)
                .ControlsAdd(buttonComplete, 2, 4)
                .ControlsAdd(buttonReport, 1, 4);

            Controls.Add(table);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Size = new Size(WIDHT, HEINGT);
            Text = Attributes.Report;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
