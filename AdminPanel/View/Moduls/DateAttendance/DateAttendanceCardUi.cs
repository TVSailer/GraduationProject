using Admin.DI.Module;
using Admin.FieldData.Model.DateAttendance.Buttons;
using DataAccess.PostgreSQL.Repository;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
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
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(parametersButtons.GetButtons(DataUi)));

    internal DataGridView OnLoadData(DataGridView gridView)
    {
        var lesson = repository.Lesson;
        var dates = repository.GetDateAttendance();

        gridView.Columns.Add("", "");

        List<object> objs = [];

        foreach (var visitor in lesson.Visitors)
        {
            objs.Add(visitor.ToString());

            foreach (var date in dates)
            {
                if (!gridView.Columns.Contains(date.Date + date.Id))
                {
                    var split = date.Date.Split(".");
                    gridView.Columns.Add(date.Date + date.Id, $"{split[0]}.{split[1]}");
                }

                objs.Add(date.Visitors!.Contains(visitor) ? "нб" : "");
            }
            gridView.Rows.Add(objs.ToArray());
            objs.Clear();
        }
        return gridView;
    }
}