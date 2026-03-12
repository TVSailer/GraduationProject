using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.View;
using Visitor.DI.Module;
using Visitor.FieldData.Lesson.LessonButton;

namespace Visitor.View.Lesson;

public class ManagerLessonPanelUi(LessonsRepository repositoryL, ManagerLessonClicked clickeds) : UiView<LessonManager>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().ContentEnd(new CardLayoutPanel<LessonEntity, LessonCard>()
                .ClickedCard(clickeds)
                .Initialize(repositoryL.Get().ToArray()))
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(clickeds.GetButtons(EventArgs.Empty)).End();
}