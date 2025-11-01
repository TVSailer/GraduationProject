using Admin.Presents;
using Logica;
using Logica.Extension;

namespace Admin.Forms.Lesson
{
    class FormDataLessons : Form
    {
        public BaseCreatingElements CreatingElements { get; set; }

        public FormDataLessons(LessonPresent present)
        {
            CreatingElements = new CreatingElements(new Style());

            var listLabel = CreatingElements.CreateListLabel(
                Attributes.NameCircle,
                Attributes.SurnameTeacher);

            var listTextBox = CreatingElements.CreateListTextBox(
                Attributes.NameCircle,
                Attributes.SurnameTeacher);

            var dataGridView = CreatingElements.CreateDataGridView();
            present.OnLoadData(ref dataGridView);

            var toolStripMenuAction = CreatingElements.CreateToolStripMenu(
                Attributes.Action,
                Attributes.Add,
                Attributes.CompleteWork);
            
            var toolStripMenuTeachers = FactoryElements.CreateToolStripMenu(
                Attributes.Teachers, "g");

            var toolStripMenuItemHelp = CreatingElements.CreateToolStripMenu(
                Attributes.Help,
                Attributes.AbountProgram);

            toolStripMenuTeachers.Click += (send, e)
                => present.OpenFormDataTeacher();

            var menuStrip = CreatingElements.CreateMenuStrip(
                toolStripMenuAction,
                toolStripMenuTeachers,
                toolStripMenuItemHelp);

            var table = CreatingElements.CreateTableLayoutPanel(5, 600, 40, 40, 40, 40, 220)
                .ControlsAdd(dataGridView, 0, 0, 5, 1)
                .ControlsAdd(new Panel(), 0, 4)
                .ControlsAdd(FactoryElements.CreateLabel(Attributes.NameCircle), 0, 1)
                .ControlsAdd(
                    FactoryElements
                        .CreateTextBox(Attributes.NameCircle)
                        .With(t => t.TextChanged += (send, e)
                            => present
                            .OnSerchData(listTextBox.Select(x => x.Text).ToArray())), 0, 2)
                .ControlsAdd(FactoryElements.CreateLabel(Attributes.SurnameTeacher), 0, 3)
                .ControlsAdd(
                    FactoryElements
                        .CreateTextBox(Attributes.SurnameTeacher)
                        .With(t => t.TextChanged += (send, e)
                            => present
                            .OnSerchData(listTextBox.Select(x => x.Text).ToArray())), 0, 4)
                .ControlsAdd(FactoryElements.CreateButton(Attributes.Add, present.OnShowFormAdding), 3, 1)
                .ControlsAdd(FactoryElements.CreateButton(Attributes.Update, present.OnUpdate), 4, 1)
                .ControlsAdd(FactoryElements.CreateButton(Attributes.Delete, present.OnDelete), 3, 2)
                .ControlsAdd(FactoryElements.CreateButton(Attributes.CompleteWork, Application.Exit), 4, 2);

            Controls.Add(table);
            Controls.Add(menuStrip);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); 
            WindowState = FormWindowState.Maximized;
            Text = Attributes.Lesson;
        }
    }
}
