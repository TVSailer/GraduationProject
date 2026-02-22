using Admin.Args;
using Admin.DI;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

namespace Admin.View;

public class VisitorDetailsUi(
    Repository<LessonEntity> repositoryL,
    VisitorDetailsFieldData viewData,
    VisitorDetailsButton parametersButtons)
    : View<VisitorDetailsFieldData, VisitorEntity>(viewData)
{
    protected override Control CreateUi()
    {
        return LayoutPanel
            .CreateColumn()
            .RowAutoSize().ContentEnd(new FieldLayoutPanel(ViewField).CreateControl())
            .RowAutoSize().ContentEnd(FactoryElements.Label_12(" Посещает:"))
            .Row().ContentEnd(OnLoadData(FactoryElements.DataGridView()))
            .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>()
                    .SetClickedData(this, new ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>(viewData))
                    .SetButtons(parametersButtons))
            .Build();
    }

    internal DataGridView OnLoadData(DataGridView gridView)
    {
        var visitor = ViewField.Entity.GetData();
        var lessons = repositoryL.Get().Where(l => l.Visitors.Contains(visitor)).ToList();

        List<DateAttendanceEntity> dates = [];
        foreach (var lesson in lessons)
            foreach (var date in lesson.AttendanceDates)
                if (dates.All(d => d.Date != date.Date))
                    dates.Add(date);

        gridView.Columns.Add("LessonName", "Занятие");

        foreach (var date in dates)
        {
            var split = date.Date.Split('.');
            var headerText = split.Length >= 2 ? $"{split[0]}.{split[1]}" : date.Date;
            gridView.Columns.Add("_", headerText);
        }

        foreach (var lesson in lessons)
        {
            var rowData = new List<object> { lesson.ToString() };

            foreach (var date in lesson.AttendanceDates)
                rowData.Add(date.Visitors != null && date.Visitors.Contains(visitor) ? "нб" : "");

            gridView.Rows.Add(rowData.ToArray());
        }

        return gridView;
    }
}
