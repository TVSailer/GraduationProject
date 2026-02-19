using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.DateAttendance;

public class DateAttendanceAddingUi : Form
{
    public DateAttendanceAddingUi(MementoLesson memento)
    {
        Size = new Size(800, 800);

        var cb = new CheckedListBox();
        cb.Dock = DockStyle.Fill;
        memento.GetVisitorsBelongingLesson().ForEach(v => cb.Items.Add(v));
        cb.CheckOnClick = true;

        Controls.Add(
            LayoutPanel.CreateColumn()
                .Row().ContentEnd(cb)
                .Row(70, SizeType.Absolute).ContentEnd(FactoryElements.Button("Сохранить", () =>
                {
                    var dl = new DateAttendanceEntity();
                    cb.CheckedItems.ForEach(s => dl.Visitors.Add((VisitorEntity)s));
                    memento.AddDateAttendance(dl);
                    Close();
                }))
                .Build()
            );
    }
}