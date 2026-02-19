using Admin.Args;
using Admin.DI;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.DateAttendance.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.DateAttendance;

public class DateAttendanceCardUi(
    MementoLesson repository,
    DateAttendanceManagment viewData,
    DateAttendanceManagmentButton parametersButtons)
    : View<DateAttendanceManagment>
{
    protected override Control CreateUi()
    {
        return LayoutPanel
            .CreateColumn()
            .Row()
            .ContentEnd(new CardLayoutPanel<DateAttendanceEntity, DateAttendanceCard>()
                .SetClickedCard(parametersButtons)
                .SetObjects(repository.GetDateAttendance()))
            .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<DateAttendanceManagment>>()
                .SetClickedData(this, new ViewButtonClickArgs<DateAttendanceManagment>(viewData))
                .SetButtons(parametersButtons))
            .Build();
    }
}