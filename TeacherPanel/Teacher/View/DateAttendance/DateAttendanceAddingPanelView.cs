using Teacher.ViewModel.DateAttendance;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Teacher.View.DateAttendance;

public class DateAttendanceAddingPanelView(DateAttendanceAddingPanelViewModel viewModel) : Forma<DateAttendanceAddingPanelViewModel>
{
    public override void Initialize()
    {
        Size = new Size(800, 800);
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
                .ChekedListBox()
                .SetData(viewModel.VisitorEntities.Keys.ToArray())
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
                    .Button("Сохранить")
                    .Command(viewModel.Add)
                .End()
            .End()
        ;
}