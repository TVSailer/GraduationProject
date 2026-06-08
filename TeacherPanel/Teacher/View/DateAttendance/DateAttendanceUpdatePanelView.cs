using Teacher.ViewModel.DateAttendance;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Teacher.View.DateAttendance;

public class DateAttendanceUpdatePanelView(DateAttendanceUdpatePanelViewModel viewModel) : Forma<DateAttendanceUdpatePanelViewModel>
{
    public override void Initialize()
    {
        Size = new Size(800, 800);
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
                .ChekedListBox()
                .SetData(viewModel.VisitorEntities)
                .CommandCheckedItem(viewModel.SelectItem)
            .End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column()
                .End()
                .Column().Content()
                    .Button("Обновить")
                    .Command(viewModel.Update)
                .End()
            .End()
    ;
}