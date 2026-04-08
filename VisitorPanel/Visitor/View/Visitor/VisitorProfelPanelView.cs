using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;
using Visitor.ViewModel.Visitor;

namespace Visitor.View.Visitor;

public class VisitorProfelPanelView(VisitorProfelPanelViewModel viewModel) : UiView<VisitorProfelPanelViewModel>
{
    const int SizeRow = 5;

    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row()
                .ColumnAutoSize().Content()
                    .Image()
                    .Binding(viewModel, nameof(viewModel.Image))
                .End()
                .Column()
                    .Row(SizeRow).Content()
                        .Label(viewModel.FIO)
                        .Size(14)
                    .End()
                    .Row(SizeRow).Content()
                        .Label(viewModel.DateBurth)
                        .Size(14)
                    .End()
                    .Row(SizeRow).Content()
                        .Label(viewModel.NumberPhone)
                        .Size(14)
                    .End()
                    .Row()
                    .End()
                .End()
                .Column().End()
            .End()
            .RowAbsolute(80)
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
