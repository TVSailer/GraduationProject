using Admin.ViewModel.DateAttendance;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;
using UserInterface.View.Base;

namespace Admin.View.DateAttendance;

public class DateAttendanceManagerPanelView(DateAttendanceManagerPanelViewModel viewModel) : UiView<DateAttendanceManagerPanelViewModel>, IView<DateAttendanceManagerPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .RowAutoSize().Content()
                .DataGridView()
                    .SetColumn("ФИО")
                    .SetColumn(viewModel.GetDateAttendance())
                    .SetRow(viewModel.GetVisitorWithAttendance())
            .End()
            .Row().End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column().Content()
                    .Button("Добавить")
                    .Command(viewModel.Add)
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