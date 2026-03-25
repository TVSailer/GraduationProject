using Admin.FieldData.Model.Teacher;
using Admin.FieldData.Model.Teacher.Buttons;
using Admin.ViewModel.Model.Teacher;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.View.Moduls.Teacher;

public class TeacherAddingPanelUi(TeacherAddingButton parametersButtons) : UiView<TeacherAddingPanelViewModel>
{
    const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
         => layout.ObjectBinding(DataUi).Column()
             .Row()
                .Column()
                    .Row(SizeRow).LabelTextBox("ФИО: ", "Введите ФИО преподователя", nameof(TeacherAddingPanelViewModel.FIOTeacher))
                    .Row(SizeRow).LabelDatePicker("Дата рождения: ", "dd.MM.yyyy", nameof(TeacherAddingPanelViewModel.DateBirth))
                    .Row(SizeRow).LabelMaskTextBox("Номер телефона: ", "+7 (000)-000-00-00", nameof(TeacherAddingPanelViewModel.NumberPhone))
                    .Row().End()
                .End()
                .Column().End()
             .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(parametersButtons.GetButtons(new ClickedArgs<TeacherAddingPanelViewModel>(DataUi))).End();
}