using DataAccess.Postgres.Models;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.DateAttendance;

public class DateAttendanceCard : ObjectCard<DateAttendanceEntity>
{
    public DateAttendanceCard() 
    {
        Size = new Size(300, 60);
    }

    public override Control Content()
        => LayoutPanel.CreateRow()
            .Column(50).ContentEnd(FactoryElements.Label_11(entity.Date).With(l => l.ForeColor = Color.DarkBlue))
            .Column(50).ContentEnd(FactoryElements.Label_11($"👥 {entity.Lesson!.Visitors.Count.ToString()}/{entity.Visitors!.Count}").With(l => l.ForeColor = Color.DarkGreen))
            .Build();
}