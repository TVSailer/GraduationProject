using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.View;
using Visitor.DI.Module;
using Visitor.FieldData.Lesson.LessonButton;

namespace Visitor.View.Lesson;

public class ManagerLessonPanelUi(LessonsRepository repositoryL, ManagerLessonButton buttons) : UiView<LessonManager>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().ContentEnd(new CardPanel<LessonEntity, LessonCard>()
                .SetClickedCard(buttons)
                .Initialize(repositoryL.Get().ToArray()))
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(buttons.GetButtons(new Empty())));
}