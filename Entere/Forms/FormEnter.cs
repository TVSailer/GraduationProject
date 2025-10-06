using Entere.Presents;
using Logica;
using System.ComponentModel;

namespace Entere.Forms
{
    class FormEnter : Form
    {
        private const int WIDHT = 800;
        private const int HEINGT = 460;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BaseCreatingElements CreatingElements { get; set; }

        public FormEnter(EnterPresent present)
        {
            CreatingElements = new CreatingElements(new Style());

            var listLabel = CreatingElements.CreateListLabel(
                Attributes.InputLogin,
                Attributes.InputPassford);

            List<TextBox> listTextBox = new();

            var textBox1 = CreatingElements.CreateTextBox(Attributes.InputLogin);
            textBox1.TextChanged += (send, e)
                => present.Login = textBox1.Text;
            listTextBox.Add(textBox1);

            var textBox2 = CreatingElements.CreateTextBox(Attributes.InputPassford);
            textBox2.TextChanged += (send, e)
                => present.Password = textBox2.Text;
            listTextBox.Add(textBox2);

            listLabel.SearchByParameter(Attributes.InputLogin).TextChanged += (send, e)
                => present.Login = listLabel.SearchByParameter(Attributes.InputLogin).Text;
            
            listLabel.SearchByParameter(Attributes.InputPassford).TextChanged += (send, e)
                => present.Password = listLabel.SearchByParameter(Attributes.InputPassford).Text;

            var linkLabelReport = CreatingElements.CreateLinkLabel(Attributes.Report);
            linkLabelReport.LinkClicked += (send, e)
                => present.OnShowReport();

            var buttonEnter = CreatingElements.CreateButton(Attributes.Enter);
            buttonEnter.Click += (send, e)
                => present.OnEnter();

            var table = CreatingElements.CreateTableLayoutPanel(3, 40, 40, 40, 40)
                .ControlsAddByColumnOrRow(listLabel, 0, 1, false)
                .ControlsAddByColumnOrRow(listTextBox, 1, 1, false)
                .ControlsAdd(linkLabelReport, 1, 3)
                .ControlsAdd(buttonEnter, 2, 4);

            Controls.Add(table);

            present.IsEnter += Close;
        }

        protected override void OnLoad(EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Size = new Size(WIDHT, HEINGT);
            Text = Attributes.Enter;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

