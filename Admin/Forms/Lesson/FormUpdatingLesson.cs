using Admin.Presents;
using DataAccess.Postgres.Models;
using Logica;

namespace Admin.Forms.Lesson
{
    public partial class FormUpdatingLesson : Form
    {
        public const int WIDHT = 600;
        public const int HEINGT = 260;

        public BaseCreatingElements CreatingElements { get; set; }

        public FormUpdatingLesson(LessonPresent present, DataGridViewRow row)
        {
            CreatingElements = new CreatingElements(new Style());

            List<Button> buttons = new();

            var textBox1 = CreatingElements.CreateTextBox(Attributes.Name);
            textBox1.TextChanged += (send, e)
                => present.Name = textBox1.Text;
            textBox1.Text = present.Name = row.Cells[1].Value.ToString();

            var comboBox = CreatingElements.CreateComboBox(
                row.Cells[3].Value,
                present.DbContext.Teachers.ToArray());
            comboBox.SelectionChangeCommitted += (send, e)
                => present.Teacher = (TeacherEntity)comboBox.SelectedItem;
            present.Teacher = (TeacherEntity)row.Cells[3].Value;

            var listLabel = CreatingElements
                .CreateListLabel(
                Attributes.NameCircle,
                Attributes.Teacher);

            var buttonAdd = CreatingElements.CreateButton(Attributes.Update);
            buttonAdd.Click += (send, e)
                => present.OnUpdate(row);
            buttonAdd.Click += (send, e)
                => Close();
            buttons.Add(buttonAdd);

            var buttonComplete = CreatingElements.CreateButton(Attributes.Complete);
            buttonComplete.Click += (send, e)
                => Close();
            buttons.Add(buttonComplete);

            var table = CreatingElements
                .CreateTableLayoutPanel(3, 30, 30, 30, 30, 30, 30)
                .ControlsAddByColumnOrRow(listLabel, 0, 0, false)
                .ControlsAdd(textBox1, 1, 0)
                .ControlsAdd(comboBox, 1, 1)
                .ControlsAddByColumnOrRow(buttons, 1, 6, true);

            Controls.Add(table);
        }

        protected override void OnLoad(EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Size = new Size(WIDHT, HEINGT);
            Text = Attributes.Update;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
