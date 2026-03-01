using Admin.FieldData.Model.Teacher.Buttons;
using UserInterface;

namespace Admin.View.Moduls.Teacher;

public class TeacherAdditionalPanelUi(
    TeacherDetailsButton parametersButtons) : TeacherPanelUi<TeacherDetailsButton>(parametersButtons)
{
    protected override Control AdditionalContent()
    {
        var dg = FactoryElements.DataGridView();
        dg.DataSource = DataUi.Entity.Lessons.Select(v => new { v.Name, v.Location }).ToList();
        return dg;
    }
}