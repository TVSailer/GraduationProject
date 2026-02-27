using Admin.Args;
using Admin.DI;
using Admin.View.Moduls.UIModel;
using Admin.View.UIModeles;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Teacher.Buttons;
using DataAccess.Postgres.Models;
using Logica.UILayerPanel;
using User_Interfase_Library.LayerPanel;

namespace Admin.View.Moduls.Teacher;

public class TeacherDetailsUi(
    TeacherDetailsFieldData viewData,
    TeacherDetailsButton parametersButtons)
    : UiView<TeacherDetailsFieldData, TeacherEntity>(viewData)
{
    protected override Control CreateUi()
    {
        return LayoutPanel
            .CreateColumn()
            .RowAutoSize().ContentEnd(new FieldLayoutPanel(FieldData).CreateControl())
            .RowAutoSize().ContentEnd(FactoryElements.Label_12(" Преподает:"))
            .Row().ContentEnd(new CardLayoutPanel<LessonEntity, LessonForTeacherCard>()
                .SetObjects(viewData.MementoEntity.Entity.Lessons))
            .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<TeacherEntity, TeacherDetailsFieldData>>()
                .SetClickedData(this, new ViewButtonClickArgs<TeacherEntity, TeacherDetailsFieldData>(viewData))
                .SetButtons(parametersButtons))
            .Build();
    }
}