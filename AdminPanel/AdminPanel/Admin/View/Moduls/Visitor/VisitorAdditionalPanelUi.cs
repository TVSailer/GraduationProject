using Admin.FieldData.Model.Teacher;
using Admin.FieldData.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface;

namespace Admin.View.Moduls.Visitor;

public class VisitorAdditionalPanelUi(
    Repository<LessonEntity> repositoryL,
    VisitorDetailsButton parametersButtons)
    : VisitorPanelUi<VisitorDetailsButton>(parametersButtons)
{
    protected override Control AdditionalContent()
    {
        var gridView = FactoryElements.DataGridView();

        var visitorId = DataUi.EntityId;
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
