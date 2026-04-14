using Teacher.ViewModel.Teacher;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Teacher.View.Teacher;

public class TeacherProfelPanelView(TeacherProfelPanelViewModel viewModel) : UiView<TeacherProfelPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row(30)
                .ColumnAutoSize().Content()
                    .Image()
                    .Binding(viewModel, nameof(viewModel.Image))
                .End()
                .Column()
                    .RowAbsolute(40).Content()
                        .Label(viewModel.FIO)
                        .Size(14)
                        .BorderStyle(BorderStyle.FixedSingle)
                    .End()
                    .RowAbsolute(40).Content()
                        .Label(viewModel.DateBurth)
                        .Size(14)
                        .BorderStyle(BorderStyle.FixedSingle)
                    .End()
                    .RowAbsolute(40).Content()
                        .Label(viewModel.NumberPhone)
                        .Size(14)
                        .BorderStyle(BorderStyle.FixedSingle)
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
                    .Button("Сменить аккаунт")
                    .Command(viewModel.ChangeAccount)
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
