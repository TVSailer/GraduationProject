using Admin.FieldData.Model.Visitor;
using DataAccess.Postgres.Models;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.View.Moduls.Visitor;

public class VisitorPanelUi<TButton>(TButton parametersButtons)
    : UiView<VisitorFieldData, VisitorEntity>
    where TButton : IButtons<VisitorFieldData>
{
    const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.ObjectBinding(DataUi).CreateColumn()
            .Row()
                .Column()
                    .Row(SizeRow).LabelTextBox("ФИО: ", "Введите ФИО преподователя", nameof(VisitorFieldData.FIOVisitor))
                    .Row(SizeRow).LabelDatePicker("Дата рождения: ", "dd.MM.yyyy", nameof(VisitorFieldData.DateBirth))
                    .Row(SizeRow).LabelMaskTextBox("Номер телефона: ", "+7 (000)-000-00-00", nameof(VisitorFieldData.NumberPhone))
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