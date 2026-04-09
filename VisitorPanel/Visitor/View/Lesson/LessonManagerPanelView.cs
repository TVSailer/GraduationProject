using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;
using Visitor.ViewModel.Lesson;

namespace Visitor.View.Lesson;

public class LessonManagerPanelView(LessonManagerPanelViewModel viewModel) : UiView<LessonManagerPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
                .CardFlowLayoutPanel<LessonEntity, LessonCard>()
                .ClickedCard(viewModel.OpenLesson)
                .Initialize(viewModel.LessonEntities)
            .End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column().Content()
                    .Button("Обновить")
                    .Command(viewModel.Update)
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
                .End()
            .End();
}