using Admin.ViewModel.Model.Visitor;
using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Admin.View.Moduls.Visitor;

public class VisitorBelongingLessonPanelView(VisitorBelongingLessonPanelViewModel viewModel) : UiView<VisitorBelongingLessonPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
                .CardFlowLayoutPanel<VisitorEntity, VisitorCard>()
                .ContextMenu("Удалить", viewModel.Delete)
                .Binding(viewModel, nameof(viewModel.VisitorEntities))
            .End()
            .RowAbsolute(80)
                .Column().Content()
                .Button("Назад")
                .Command(viewModel.Exit)
            .End()
                .Column().Content()
                .Button("Добавить существующего")
                .Command(viewModel.LoadVisitorNotBelogingLessonPanelView)
            .End()
                .Column().Content()
                .Button("Добавить нового")
                .Command(viewModel.LoadVisitorAddingPanelView)
            .End()
            .Column().Content()
                .Button()
                .End()
            .End();
}