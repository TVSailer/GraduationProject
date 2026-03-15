using Admin.FieldData.Model.Visitor;
using Admin.FieldData.Model.Visitor.Buttons;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.View.Moduls.Visitor;

public class VisitorAddingPanelUi(VisitorAddingButton parametersButtons) : UiView<VisitorFieldData>
{
    const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.ObjectBinding(DataUi).Column()
            .Row()
                .Column()
                    .Row(SizeRow).LabelTextBox("ФИО: ", "Введите ФИО преподователя", nameof(VisitorFieldData.FIOVisitor))
                    .Row(SizeRow).LabelDatePicker("Дата рождения: ", "dd.MM.yyyy", nameof(VisitorFieldData.DateBirth))
                    .Row(SizeRow).LabelMaskTextBox("Номер телефона: ", "+7 (000)-000-00-00", nameof(VisitorFieldData.NumberPhone))
                    .Row().End()
                .End()
            .Column().End()
            .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(parametersButtons.GetButtons(new ClickedArgs<VisitorFieldData>(DataUi))).End();
}