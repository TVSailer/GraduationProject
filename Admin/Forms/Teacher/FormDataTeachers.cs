using Admin.Presents;
using Logica;

namespace Admin.Forms.Teacher
{
    public class FormDataTeachers : Form
    {
        public readonly BaseCreatingElements CreatingElements;

        public FormDataTeachers(TeacherPresent present)
        {
            CreatingElements = new CreatingElements(new Style());

            var dataGridView = CreatingElements.CreateDataGridView();
            present.OnLoadData(ref dataGridView);

            var listTextBox = CreatingElements.CreateListTextBox(
                Attributes.Name,
                Attributes.Surname,
                Attributes.Patronymic);

            var listLabel = CreatingElements.CreateListLabel(
                Attributes.Serch,
                Attributes.Name,
                Attributes.Surname,
                Attributes.Patronymic);

            var listButton = CreatingElements.CreateListButton(
                Attributes.Delete,
                Attributes.Add,
                Attributes.Close,
                Attributes.Update);

            listTextBox.ForEach(x => x.TextChanged += (send, e)
                => present.OnSerchData(listTextBox.Select(x => x.Text).ToArray()));

            listButton.SearchByParameter(Attributes.Add).Click += (send, e)
                => present.OnShowFormAdding();

            listButton.SearchByParameter(Attributes.Update).Click += (send, e)
                => present.OnUpdate();

            listButton.SearchByParameter(Attributes.Delete).Click += (send, e)
                => present.OnDelete();

            listButton.SearchByParameter(Attributes.Close).Click += (send, e)
                => Close();

            var table = CreatingElements.CreateTableLayoutPanel(5, 600, 40, 40, 40, 40, 40, 180)
                .ControlsAdd(dataGridView, 0, 0, 5, 1)
                .ControlsAdd(listLabel.SearchByParameter(Attributes.Name), 0, 1)
                .ControlsAdd(listLabel.SearchByParameter(Attributes.Surname), 0, 3)
                .ControlsAdd(listLabel.SearchByParameter(Attributes.Patronymic), 0, 5)
                .ControlsAdd(listTextBox.SearchByParameter(Attributes.Name), 0, 2)
                .ControlsAdd(listTextBox.SearchByParameter(Attributes.Surname), 0, 4)
                .ControlsAdd(listTextBox.SearchByParameter(Attributes.Patronymic), 0, 6)
                .ControlsAdd(listButton.SearchByParameter(Attributes.Add), 3, 1)
                .ControlsAdd(listButton.SearchByParameter(Attributes.Update), 4, 1)
                .ControlsAdd(listButton.SearchByParameter(Attributes.Delete), 3, 2)
                .ControlsAdd(listButton.SearchByParameter(Attributes.Close), 4, 2)
                .ControlsAdd(new Panel(), 0, 7);

            Controls.Add(table);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WindowState = FormWindowState.Maximized;
            Text = "Учителя";
        }
    }
}
