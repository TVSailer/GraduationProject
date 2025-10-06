using Admin.Presents;
using Logica;

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

            listTextBox.ForEach(x => x.TextChanged += (send, e)
                => present.OnSerchData(listTextBox.Select(x => x.Text).ToArray()));

            var dataGridView = CreatingElements.CreateDataGridView();
            present.OnLoadData(ref dataGridView);

            var toolStripMenuAction = CreatingElements.CreateToolStripMenu(
                Attributes.Action,
                Attributes.Add,
                Attributes.CompleteWork);
            
            var toolStripMenuTeachers = CreatingElements.CreateToolStripMenu(
                Attributes.Teachers);

            var toolStripMenuItemHelp = CreatingElements.CreateToolStripMenu(
                Attributes.Help,
                Attributes.AbountProgram);

            toolStripMenuTeachers.Click += (send, e)
                => present.OpenFormDataTeacher();

            var menuStrip = CreatingElements.CreateMenuStrip(
                toolStripMenuAction,
                toolStripMenuTeachers,
                toolStripMenuItemHelp);

            var listButton = CreatingElements.CreateListButton(
                Attributes.Add,
                Attributes.CompleteWork,
                Attributes.Delete,
                Attributes.Update);

            listButton.SearchByParameter(Attributes.Add).Click += (send, e)
                => present.OnShowFormAdding();
            
            listButton.SearchByParameter(Attributes.Delete).Click += (send, e)
                => present.OnDelete();
            
            listButton.SearchByParameter(Attributes.Update).Click += (send, e)
                => present.OnUpdate();

            listButton.SearchByParameter(Attributes.CompleteWork).Click += (send, e)
                => Application.Exit();

            var table = CreatingElements.CreateTableLayoutPanel(5, 600, 40, 40, 40, 40, 220)
                .ControlsAdd(dataGridView, 0, 0, 5, 1)
                .ControlsAdd(new Panel(), 0, 4)
                .ControlsAdd(listLabel.SearchByParameter(Attributes.NameCircle), 0, 1)
                .ControlsAdd(listTextBox.SearchByParameter(Attributes.NameCircle), 0, 2)
                .ControlsAdd(listLabel.SearchByParameter(Attributes.SurnameTeacher), 0, 3)
                .ControlsAdd(listTextBox.SearchByParameter(Attributes.SurnameTeacher), 0, 4)
                .ControlsAdd(listButton.SearchByParameter(Attributes.Add), 3, 1)
                .ControlsAdd(listButton.SearchByParameter(Attributes.Update), 4, 1)
                .ControlsAdd(listButton.SearchByParameter(Attributes.Delete), 3, 2)
                .ControlsAdd(listButton.SearchByParameter(Attributes.CompleteWork), 4, 2);

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
