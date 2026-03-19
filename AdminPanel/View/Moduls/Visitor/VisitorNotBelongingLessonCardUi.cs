using Admin.DI.Module;
using Admin.FieldData.Model.Visitor.Buttons;
using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.View.Moduls.Visitor;

public class VisitorNotBelongingLessonCardUi(
    MementoLesson repository,
    VisitorNotBelongingLessonClicked parametersClickeds) : UiView<VisitorNotBelongingLesson>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().ContentEnd(new CardFlowPanel<VisitorEntity, VisitorCard>()
                .SetClickedCard(parametersClickeds)
                .Initialize(repository.GetVisitorsNotBelongingLesson().ToArray()))
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(parametersClickeds.GetButtons(new ClickedArgs<VisitorNotBelongingLesson>(DataUi))).End();
}