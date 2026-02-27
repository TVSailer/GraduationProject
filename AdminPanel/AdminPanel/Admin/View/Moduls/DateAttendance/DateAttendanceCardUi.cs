using Admin.Args;
using Admin.DI;
using Admin.View.Moduls.UIModel;
using Admin.View.UIModeles;
using Admin.View.ViewForm;
using DataAccess.Postgres.Repository;
using User_Interface_Library;
using User_Interface_Library.LayerPanel;
using User_Interfase_Library.LayerPanel;

namespace Admin.View.Moduls.DateAttendance;

public class DateAttendanceCardUi(
    MementoLesson repository,
    DateAttendanceManagment viewData,
    DateAttendanceManagmentButton parametersButtons)
    : UiView<DateAttendanceManagment>
{
    protected override Control CreateUi()
    {
        return LayoutPanel.CreateColumn()
            .RowAutoSize().ContentEnd(OnLoadData(FactoryElements.DataGridView()))
            .Row().End()
            .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<DateAttendanceManagment>>()
                .SetClickedData(this, new ViewButtonClickArgs<DateAttendanceManagment>(viewData))
                .SetButtons(parametersButtons))
            .Build();
    }

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