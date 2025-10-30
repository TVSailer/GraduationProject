using Admin.Presents;
using Logica;
using Logica.Extension;

namespace Admin.Forms.Teacher
{
    public class FormDataTeachers : Form
    {
        public FormDataTeachers(TeacherPresent present)
        {
            var dataGridView = FactoryElements.CreateDataGridView();
            present.OnLoadData(ref dataGridView);

            var listTextBox = FactoryElements.CreateListTextBox(
                Attributes.Name,
                Attributes.Surname,
                Attributes.Patronymic);

            listTextBox.ForEach(x => x.TextChanged += (send, e)
                => present.OnSerchData(listTextBox.Select(x => x.Text).ToArray()));

            var table = 
                FactoryElements
                .CreateTableLayoutPanel(5, 600, 40, 40, 40, 40, 40, 180)
                .ControlsAdd(dataGridView, 0, 0, 5, 1)
                .ControlsAdd(FactoryElements.CreateLabel(Attributes.Name), 0, 1)
                .ControlsAdd(listTextBox[0], 0, 2)
                .ControlsAdd(FactoryElements.CreateLabel(Attributes.Surname), 0, 3)
                .ControlsAdd(listTextBox[1], 0, 4)
                .ControlsAdd(FactoryElements.CreateLabel(Attributes.Patronymic), 0, 5)
                .ControlsAdd(listTextBox[2], 0, 6)
                .ControlsAdd(FactoryElements.CreateButton(Attributes.Add, present.OnShowFormAdding), 3, 1)
                .ControlsAdd(FactoryElements.CreateButton(Attributes.Update, present.OnUpdate), 4, 1)
                .ControlsAdd(FactoryElements.CreateButton(Attributes.Delete, present.OnDelete), 3, 2)
                .ControlsAdd(FactoryElements.CreateButton(Attributes.Close, Close), 4, 2)
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
