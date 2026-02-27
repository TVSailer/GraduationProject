using Admin.Args;
using Admin.DI;
using Admin.View.Moduls.UIModel;
using Admin.View.UIModeles;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;
using User_Interfase_Library.LayerPanel;

namespace Admin.View;

public class VisitorDetailsUi(
    Repository<LessonEntity> repositoryL,
    VisitorDetailsFieldData viewData,
    VisitorDetailsButton parametersButtons)
    : UiView<VisitorDetailsFieldData, VisitorEntity>(viewData)
{
    protected override Control CreateUi()
    {
        return LayoutPanel
            .CreateColumn()
            .RowAutoSize().ContentEnd(new FieldLayoutPanel(FieldData).CreateControl())
            .RowAutoSize().ContentEnd(FactoryElements.Label_12(" Посещает:"))
            .Row().ContentEnd(OnLoadData(FactoryElements.DataGridView()))
            .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>()
                    .SetClickedData(this, new ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>(viewData))
                    .SetButtons(parametersButtons))
            .Build();
    }

    internal DataGridView OnLoadData(DataGridView gridView)
    {
        var visitorId = FieldData.MementoEntity.Id;
        var lessons = repositoryL.Get().Where(l => l.Visitors.Select(v => v.Id).Contains(visitorId)).ToList();

        List<DateAttendanceEntity> dates = [];
        foreach (var date in 
                 from lesson in lessons 
                 from date in lesson.AttendanceDates 
                 where dates.All(d => d.Date != date.Date) 
                 select date)
            dates.Add(date);

        gridView.Columns.Add("LessonName", "Занятие");

        foreach (var headerText in 
                 from date in dates 
                 let split = date.Date.Split('.') 
                 select split.Length >= 2 ? $"{split[0]}.{split[1]}" : date.Date)
            gridView.Columns.Add("_", headerText);

        foreach (var lesson in lessons)
        {
            var rowData = new List<object> { lesson.ToString() };
            rowData.AddRange(lesson.AttendanceDates
                .Select(date => date.Visitors != null && date.Visitors
                    .Select(v => v.Id)
                    .Contains(visitorId) ? "нб" : ""));

            gridView.Rows.Add(rowData.ToArray());
        }

        return gridView;
    }
}
