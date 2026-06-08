using Teacher.ViewModel.DateAttendance;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Teacher.View.DateAttendance;

public class DateAttendanceManagerPanelView(DateAttendanceManagerPanelViewModel viewModel) : UiView<DateAttendanceManagerPanelViewModel>
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
                    .Button(viewModel.NameButton)
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