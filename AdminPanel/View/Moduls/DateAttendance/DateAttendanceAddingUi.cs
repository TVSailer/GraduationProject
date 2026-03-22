using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using ExtensionFunc;
using UserInterface;
using UserInterface.LayoutPanel;

namespace Admin.View.Moduls.DateAttendance;

public class DateAttendanceAddingPanelUi : Form
{
    public DateAttendanceAddingPanelUi(MementoLesson memento)
    {
        Size = new Size(800, 800);

        var cb = new CheckedListBox();
        cb.Dock = DockStyle.Fill;
        memento.Lesson.Visitors.ForEach(v => cb.Items.Add(v));
        cb.CheckOnClick = true;

        Controls.Add(
            new BuilderLayoutPanel().Column()
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