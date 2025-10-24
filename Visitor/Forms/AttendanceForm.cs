using Logica;

namespace Visitor;
public partial class AttendanceForm : Form
{
    public BaseCreatingElements CreatingElements = new CreatingElements(new Style());
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        WindowState = FormWindowState.Maximized;
        Text = "Посещаемость";
    }
}

public partial class AttendanceForm : Form
{
    public AttendanceForm()
    {
        var dataGridView = CreatingElements.CreateDataGridView();

        var listButton = CreatingElements.CreateListButton(
                Attributes.AddDate,
                Attributes.CompleteWork,
                Attributes.Serch);

        var table = CreatingElements.CreateTableLayoutPanel(10, 300, 800, 260)
                .ControlsAdd(dataGridView, 1, 1, 9, 1)
                .ControlsAdd(new Panel(), 0, 0)
                .ControlsAdd(new Panel(), 10, 0)
                .ControlsAdd(new Panel(), 0, 10)
                .ControlsAdd(new Panel(), 10, 10);

        Controls.Add(table);
    }
}
