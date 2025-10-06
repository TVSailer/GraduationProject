using Logica;
using Teacher.Presents;

namespace Teacher.Forms.Visitors
{
    public partial class FormAddingVisitor : Form
    {
        public const int WIDHT = 400;
        public const int HEINGT = 260;

        public BaseCreatingElements CreatingElements { get; set; }

        public FormAddingVisitor(VisitorPresent present)
        {
            CreatingElements = new CreatingElements(new Style());

            List<Button> buttons = new();
            List<TextBox> textBoxes = new();

            var dateBirth = CreatingElements.CreateDateTimePicker(Attributes.DateBirth);
            dateBirth.TextChanged += (send, e)
                => present.DateBirth = dateBirth.Text;

            var textBox1 = CreatingElements.CreateTextBox(Attributes.Name);
            textBox1.TextChanged += (send, e)
                => present.Name = textBox1.Text;
            textBoxes.Add(textBox1);
            
            var textBox2 = CreatingElements.CreateTextBox(Attributes.Surname);
            textBox2.TextChanged += (send, e)
                => present.Surname = textBox2.Text;
            textBoxes.Add(textBox2);

            var textBox3 = CreatingElements.CreateTextBox(Attributes.Patronymic);
            textBox3.TextChanged += (send, e)
                => present.Patronymic = textBox3.Text;
            textBoxes.Add(textBox3);

            var textBox4 = CreatingElements.CreateTextBox(Attributes.NumberPhone);
            textBox4.TextChanged += (send, e)
                => present.NumberPhone = textBox4.Text;
            textBoxes.Add(textBox4);

            var listLabel = CreatingElements
                .CreateListLabel(
                Attributes.Name,
                Attributes.Surname,
                Attributes.Patronymic,
                Attributes.NumberPhone,
                Attributes.DateBirth);

            var buttonAdd = CreatingElements.CreateButton(Attributes.Add);
            buttonAdd.Click += (send, e)
                => present.OnAdd();
            buttons.Add(buttonAdd);

            var buttonComplete = CreatingElements.CreateButton(Attributes.Complete);
            buttonComplete.Click += (send, e)
                => Close();

            buttons.Add(buttonComplete);

            var table = CreatingElements
                .CreateTableLayoutPanel(3, 30, 30, 30, 30, 30, 30)
                .ControlsAddByColumnOrRow(listLabel, 0, 0, false)
                .ControlsAddByColumnOrRow(textBoxes, 1, 0, false)
                .ControlsAddByColumnOrRow(buttons, 1, 6, true)
                .ControlsAdd(dateBirth, 1, 4);

            Controls.Add(table);
        }

        protected override void OnLoad(EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Size = new Size(WIDHT, HEINGT);
            Text = Attributes.AddVisitor;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
