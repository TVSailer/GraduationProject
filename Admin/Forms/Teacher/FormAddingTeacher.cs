using Admin.Presents;
using Logica;
using Logica.Extension;

namespace Admin.Forms.Teacher
{
    public class FormAddingTeacher : Form
    {
        public const int WIDHT = 400;
        public const int HEINGT = 280;

        public FormAddingTeacher(TeacherPresent present)
        {
            var dateBirth = FactoryElements.CreateDateTimePicker(Attributes.DateBirth)
                .With(d => d.TextChanged += (send, e) => present.DateBirth = d.Text);

            List<TextBox> listTextBoxes = new()
            {
                FactoryElements.CreateTextBox(Attributes.Name)
                    .With(t => t.TextChanged += (send, e) => present.Name = t.Text),
                FactoryElements.CreateTextBox(Attributes.Surname)
                    .With(t => t.TextChanged += (send, e) => present.Surname = t.Text),
                FactoryElements.CreateTextBox(Attributes.Patronymic)
                    .With(t => t.TextChanged += (send, e) => present.Patronymic = t.Text),
                FactoryElements.CreateTextBox(Attributes.NumberPhone)
                    .With(t => t.TextChanged += (send, e) => present.NumberPhone = t.Text)

            };

            var listLabel = FactoryElements
                .CreateListLabel(
                Attributes.Name,
                Attributes.Surname,
                Attributes.Patronymic,
                Attributes.NumberPhone,
                Attributes.DateBirth);

            List<Button> listButtons = new()
            {
                FactoryElements.CreateButton(Attributes.Add)
                    .With(b => b.Click += (send, e) => present.OnAdd()),
                FactoryElements.CreateButton(Attributes.Complete)
                    .With(b => b.Click += (send, e) => Close()),
            };

            var table = FactoryElements
                .CreateTableLayoutPanel(3, 30, 30, 30, 30, 30, 40)
                .ControlsAddByColumnOrRow(listLabel, 0, 0, false)
                .ControlsAddByColumnOrRow(listTextBoxes, 1, 0, false)
                .ControlsAddByColumnOrRow(listButtons, 1, 6, true)
                .ControlsAdd(dateBirth, 1, 4);

            Controls.Add(table);
        }

        protected override void OnLoad(EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Size = new Size(WIDHT, HEINGT);
            Text = Attributes.AddTeacher;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
