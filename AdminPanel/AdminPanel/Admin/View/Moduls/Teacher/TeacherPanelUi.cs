using Admin.FieldData.Model.Teacher;
using DataAccess.Postgres.Models;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.View.Moduls.Teacher;

public class TeacherPanelUi<TButton>(TButton parametersButtons) : UiView<TeacherFieldData, TeacherEntity>
    where TButton : IButtons<TeacherFieldData>
{
    const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
         => layout.ObjectBinding(DataUi).CreateColumn()
             .Row()
                .Column()
                    .Row(SizeRow).LabelTextBox("ФИО: ", "Введите ФИО преподователя", nameof(TeacherFieldData.FIOTeacher))
                    .Row(SizeRow).LabelDatePicker("Дата рождения: ", "dd.MM.yyyy", nameof(TeacherFieldData.DateBirth))
                    .Row(SizeRow).LabelMaskTextBox("Номер телефона: ", "+7 (000)-000-00-00", nameof(TeacherFieldData.NumberPhone))
                    .Row(SizeRow).ContentEnd(FactoryElements.Label_12(" Преподает:"))
                    .Row().ContentEnd(AdditionalContent())
                .End()
                .Column().End()
             .End()
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(parametersButtons.GetButtons(DataUi)));

    protected virtual Control AdditionalContent()
    {
        return new EmptyPanel();
    }
}

