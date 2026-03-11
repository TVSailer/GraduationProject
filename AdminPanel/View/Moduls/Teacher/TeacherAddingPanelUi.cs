using Admin.FieldData.Model.Teacher;
using Admin.FieldData.Model.Teacher.Buttons;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.View.Moduls.Teacher;

public class TeacherAddingPanelUi(TeacherAddingButton parametersButtons) : UiView<TeacherFieldData>
{
    const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
         => layout.ObjectBinding(DataUi).Column()
             .Row()
                .Column()
                    .Row(SizeRow).LabelTextBox("ФИО: ", "Введите ФИО преподователя", nameof(TeacherFieldData.FIOTeacher))
                    .Row(SizeRow).LabelDatePicker("Дата рождения: ", "dd.MM.yyyy", nameof(TeacherFieldData.DateBirth))
                    .Row(SizeRow).LabelMaskTextBox("Номер телефона: ", "+7 (000)-000-00-00", nameof(TeacherFieldData.NumberPhone))
                    .Row().End()
                .End()
                .Column().End()
             .End()
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(parametersButtons.GetButtons(DataUi)));
}