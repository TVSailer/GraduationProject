using Admin.DI.Module;
using Admin.FieldData.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.View;

namespace Admin.View.Moduls.Visitor;

public class VisitorNotBelongingLessonCardUi(
    MementoLesson repository,
    VisitorNotBelongingLessonButton parametersButtons) : UiView<VisitorNotBelongingLesson>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.CreateColumn()
            .Row().ContentEnd(new CardLayoutPanel<VisitorEntity, VisitorCard>()
                .SetClickedCard(parametersButtons)
                .Initialize(repository.GetVisitorsNotBelongingLesson().ToArray()))
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(parametersButtons.GetButtons(DataUi)));
}