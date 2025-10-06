using Admin.Presents;
using DataAccess.Postgres.Models;
using Logica;

namespace Admin.Forms.Lesson
{
    public class FormAddingLesson : Form
    {
        public const int WIDHT = 600;
        public const int HEINGT = 260;

        public BaseCreatingElements CreatingElements { get; set; }

        public FormAddingLesson(LessonPresent present)
        {
            CreatingElements = new CreatingElements(new Style());

            List<Button> buttons = new();

            var textBox1 = CreatingElements.CreateTextBox(Attributes.NameCircle);
            textBox1.TextChanged += (send, e)
                => present.Name = textBox1.Text;

            var comboBox = CreatingElements.CreateComboBox(
                "", 
                present.DbContext.Teachers.ToArray());

            comboBox.SelectionChangeCommitted += (send, e)
                => present.Teacher = (TeacherEntity)comboBox.SelectedItem;

            var listLabel = CreatingElements
                .CreateListLabel(
                Attributes.NameCircle,
                Attributes.Teacher);

            var buttonAdd = CreatingElements.CreateButton(Attributes.Add);
            buttonAdd.Click += (send, e)
                => present.OnAdd();
            buttons.Add(buttonAdd);

            var buttonComplete = CreatingElements.CreateButton(Attributes.Complete);
            buttonComplete.Click += (send, e)
                => Close();
            buttons.Add(buttonComplete);

            var table = CreatingElements
                .CreateTableLayoutPanel(3, 30, 30, 30, 90)
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
            Text = Attributes.AddLesson;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
