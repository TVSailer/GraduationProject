using Admin.DI.Module;
using Admin.FieldData.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
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
        => builderLayoutPanel.CreateColumn()
            .Row()
            .ContentEnd(new CardLayoutPanel<VisitorEntity, VisitorCard>()
                .SetContextMenu(parametersButtons)
                .Initialize(repository.GetVisitorsBelongingLesson().ToArray()))
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(parametersButtons.GetButtons(DataUi)));
}