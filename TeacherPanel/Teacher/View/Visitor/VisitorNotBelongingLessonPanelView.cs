using Domain.Entitys;
using Teacher.ViewModel.Visitor;
using UserInterface.LayoutPanel;
using UserInterface.View;

namespace Teacher.View.Visitor;

public class VisitorNotBelongingLessonPanelView(VisitorNotBelongingLessonPanelViewModel viewModel) : UiView<VisitorNotBelongingLessonPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
                .CardFlowLayoutPanel<VisitorEntity, VisitorCard>()
                .ContextMenu("Добавить", viewModel.AddVisitor)
                .Binding(viewModel, nameof(viewModel.VisitorEntities))
            .End()
            .Row(80, SizeType.Absolute)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
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