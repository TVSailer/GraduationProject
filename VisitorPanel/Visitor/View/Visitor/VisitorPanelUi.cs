using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Models;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.FieldData.Visitor.Button;

namespace Visitor.View.Visitor;

public class VisitorPanelUi(VisitorButtons buttons) : UiView<MementoVisitor>
{
    const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.ObjectBinding(DataUi.Visitor).Column()
            .Row()
                .Column()
                    .Row(SizeRow).LabelTextBoxReadOnly("ФИО: ", nameof(VisitorEntity.FIO))
                    .Row(SizeRow).LabelTextBoxReadOnly("Дата рождения: ", nameof(VisitorEntity.DateBirth))
                    .Row(SizeRow).LabelTextBoxReadOnly("Номер телефона: ", nameof(VisitorEntity.NumberPhone))
                    .Row().ContentEnd(AdditionalContent())
                .End()
                .Column().End()
            .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(buttons.GetButtons(new ClickedArgs<VisitorEntity>(DataUi.Visitor))).End();

    protected Control AdditionalContent()
    {
        var gridView = FactoryElements.DataGridView();

        gridView.Columns.Add("LessonName", "Занятие");
        foreach (var headerText in DataUi.Visitor.Dates.Select(d => d.ToString("dd/MM")))
            gridView.Columns.Add("_", headerText);
        foreach (object[] data in DataUi.Visitor.GetLessonWithAttendance())
            gridView.Rows.Add(data);
        return gridView;
    }
}
