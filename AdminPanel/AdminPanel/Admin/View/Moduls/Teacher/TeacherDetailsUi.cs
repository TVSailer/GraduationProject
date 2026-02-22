using Admin.Args;
using Admin.DI;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Teacher.Buttons;
using DataAccess.Postgres.Models;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.Teacher;

public class TeacherDetailsUi(
    TeacherDetailsFieldData viewData,
    TeacherDetailsButton parametersButtons)
    : View<TeacherDetailsFieldData, TeacherEntity>(viewData)
{
    protected override Control CreateUi()
    {
        return LayoutPanel
            .CreateColumn()
            .RowAutoSize().ContentEnd(new FieldLayoutPanel(ViewField).CreateControl())
            .RowAutoSize().ContentEnd(FactoryElements.Label_12(" Преподает:"))
            .Row().ContentEnd(new CardLayoutPanel<LessonEntity, LessonForTeacherCard>()
                .SetObjects(viewData.Entity.GetData().Lessons!))
            .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<TeacherEntity, TeacherDetailsFieldData>>()
                .SetClickedData(this, new ViewButtonClickArgs<TeacherEntity, TeacherDetailsFieldData>(viewData))
                .SetButtons(parametersButtons))
            .Build();
    }
}