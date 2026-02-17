using Logica;
using Teacher.Presents;

namespace Teacher.Forms.Dates
{
    class FormTreckingAttendance : Form
    {
        public BaseCreatingElements CreatingElements { get; set; }

        public FormTreckingAttendance(DatePresent present)
        {
            CreatingElements = new CreatingElements(new Style());

            var listTextBox = CreatingElements.CreateListTextBox(Attributes.Serch);

            var dataGridView = CreatingElements.CreateDataGridView();
            present.OnLoadData(ref dataGridView);

            var comboBoxSearch = CreatingElements.CreateComboBox(
                Attributes.SearchBy,
                Attributes.Name,
                Attributes.Surname,
                Attributes.Patronymic);

            var toolStripMenuAction = CreatingElements.CreateToolStripMenu(
                Attributes.Action,
                Attributes.AddDate,
                Attributes.CompleteWork);
            
            var toolStripMenuVisitors = CreatingElements.CreateToolStripMenu(
                Attributes.Visitors);

            var toolStripMenuLessons = CreatingElements.CreateToolStriDropDownButton(Attributes.Lesson, present.OnChosseLesson,
                present.Teacher.Lessons.Select(l => l.ToString()).ToArray() ?? throw new ArgumentException());

            var toolStripMenuItemHelp = CreatingElements.CreateToolStripMenu(
                Attributes.Help,
                Attributes.AbountProgram);

            toolStripMenuVisitors.Click += (send, e)
                => present.OpenFormDataVisitors();

            var menuStrip = CreatingElements.CreateMenuStrip(
                toolStripMenuAction,
                toolStripMenuVisitors,
                toolStripMenuLessons,
                toolStripMenuItemHelp);

            var listButton = CreatingElements.CreateListButton(
                Attributes.AddDate,
                Attributes.CompleteWork,
                Attributes.Serch);

            listButton.SearchByParameter(Attributes.AddDate).Click += (send, e)
                => present.OnShowFormAddingDate(ref dataGridView);
            
            listButton.SearchByParameter(Attributes.CompleteWork).Click += (send, e)
                => Application.Exit();

            var table = CreatingElements.CreateTableLayoutPanel(5, 600, 40, 40, 40, 260)
                .ControlsAdd(dataGridView, 0, 0, 5, 1)
                .ControlsAdd(new Panel(), 0, 4)
                .ControlsAdd(comboBoxSearch, 0, 1)
                .ControlsAdd(listTextBox.SearchByParameter(Attributes.Serch), 0, 2)
                .ControlsAdd(listButton.SearchByParameter(Attributes.Serch), 0, 3)
                .ControlsAdd(listButton.SearchByParameter(Attributes.AddDate), 3, 1)
                .ControlsAdd(listButton.SearchByParameter(Attributes.CompleteWork), 4, 1);

            Controls.Add(table);
            Controls.Add(menuStrip);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); 
            WindowState = FormWindowState.Maximized;
            Text = "Посещаемость";
        }
    }
}
