using Admin.DI.Module;
using Admin.FieldData.Model.DateAttendance.Buttons;
using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Repository;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.View.Moduls.DateAttendance;

public class DateAttendancePanelUi(
    MementoLesson repository,
    DateAttendanceManagerButton parametersButtons)
    : UiView<DateAttendanceManager>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .RowAutoSize().ContentEnd(OnLoadData(FactoryElements.DataGridView()))
            .Row().End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(parametersButtons.GetButtons(new ClickedArgs<DateAttendanceManager>(DataUi))).End();

    internal DataGridView OnLoadData(DataGridView gridView)
    {
        var lesson = repository.Lesson;

        gridView.Columns.Add("", "");

        foreach (var headerText in lesson!.AttendanceDates.Select(d => d.ToString("dd/MM")))
            gridView.Columns.Add("_", headerText);
        foreach (object[] data in lesson.GetVisitorWithAttendance())
            gridView.Rows.Add(data);
        return gridView;
    }
}