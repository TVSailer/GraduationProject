using Admin.Args;
using Admin.DI;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.DateAttendance.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.UILayerPanel;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Admin.View.Moduls.DateAttendance;

public class DateAttendanceCardUi(
    MementoLesson repository,
    DateAttendanceManagment viewData,
    DateAttendanceManagmentButton parametersButtons)
    : View<DateAttendanceManagment>
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
        gridView.Columns.Clear();
        gridView.Rows.Clear();

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
                    gridView.Columns.Add(date.Date + date.Id, $"{split[0]}.{split[1]}\n{split[2]}");
                }

                var rez = date.Visitors
                    .FirstOrDefault(d => d.Id == visitor.Id) == null;

                objs.Add(!rez ? "нб" : "");
            }
            gridView.Rows.Add(objs.ToArray());
            objs.Clear();
        }
        return gridView;
    }
}