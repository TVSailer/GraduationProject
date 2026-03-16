using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Models;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.FieldData.Visitor.Button;

namespace Visitor.FieldData.Visitor;

public class VisitorPanelUi(MementoVisitor mementoVisitor, VisitorButtons buttons) : UiView<MementoVisitor>
{
    const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.ObjectBinding(DataUi.Visitor).Column()
            .Row()
            .Column()
            .Row(SizeRow).LabelTextBoxReadOnly("ФИО: ", "Введите ФИО преподователя", nameof(VisitorFieldData.FIOVisitor))
            .Row(SizeRow).LabelDatePicker("Дата рождения: ", "dd.MM.yyyy", nameof(VisitorFieldData.DateBirth))
            .Row(SizeRow).LabelMaskTextBox("Номер телефона: ", "+7 (000)-000-00-00", nameof(VisitorFieldData.NumberPhone))
            .Row().ContentEnd(AdditionalContent())
            .End()
            .Column().End()
            .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(parametersButtons.GetButtons(new ClickedArgs<VisitorFieldData>(DataUi))).End();

    protected Control AdditionalContent()
    {
        var gridView = FactoryElements.DataGridView();

        gridView.Columns.Add("LessonName", "Занятие");
        foreach (var headerText in DataUi.Entity.Dates.Select(d => d.ToString("dd/MM")))
            gridView.Columns.Add("_", headerText);
        foreach (object[] data in DataUi.Entity.GetLessonWithAttendance())
            gridView.Rows.Add(data);
        return gridView;
    }
}
