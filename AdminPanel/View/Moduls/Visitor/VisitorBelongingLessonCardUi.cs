using Admin.DI.Module;
using Admin.FieldData.Model.Visitor.Buttons;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.View;

namespace Admin.View.Moduls.Visitor;

public class VisitorBelongingLessonCardUi(
    MementoLesson repository,
    VisitorBelongingLessonButton parametersButtons) : UiView<VisitorBelongingLesson>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row()
            .ContentEnd(new CardFlowPanel<VisitorEntity, VisitorCard>()
                .SetContextMenu(parametersButtons)
                .Initialize(repository.GetVisitorsBelongingLesson().ToArray()))
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(parametersButtons.GetButtons(DataUi)));
}