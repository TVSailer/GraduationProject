using Admin.FieldData.Model.Teacher;
using Admin.FieldData.Model.Teacher.Buttons;
using DataAccess.PostgreSQL.ModelsPrimitive;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.View.Moduls.Teacher;

public class TeacherDetailsPanelUi(TeacherDetailsButton parametersButtons) : UiView<TeacherFieldData, TeacherEntity>
{
    const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.ObjectBinding(DataUi).Column()
            .Row()
                .Column()
                    .Row(SizeRow).LabelTextBox("ФИО: ", "Введите ФИО преподователя", nameof(TeacherFieldData.FIOTeacher))
                    .Row(SizeRow).LabelDatePicker("Дата рождения: ", "dd.MM.yyyy", nameof(TeacherFieldData.DateBirth))
                    .Row(SizeRow).LabelMaskTextBox("Номер телефона: ", "+7 (000)-000-00-00", nameof(TeacherFieldData.NumberPhone))
                    .Row(SizeRow).Content().Label(" Преподает:").End()
                    .Row().ContentEnd(AdditionalContent())
                .End()
            .Column().End()
            .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(parametersButtons.GetButtons(new ClickedArgs<TeacherFieldData>(DataUi))).End();

    protected virtual Control AdditionalContent()
    {
        var dg = FactoryElements.DataGridView();
        dg.Columns.Add("Name", "Название");
        dg.Columns.Add("Location", "Место проведения");
        DataUi.Entity.Lessons.ForEach(v => dg.Rows.Add(v.Name, v.Location));
        return dg;
    }
}