using Admin.DI;
using Admin.DI.Module;
using Admin.ViewModel.Model.Teacher;
using DataAccess.PostgreSQL.ModelsPrimitive;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Teacher.Buttons;

public class TeacherManagerClicked(
    ControlView controlView) : 
    IButtons<TeacherManager>,
    IToolStrip<TeacherEntity>, 
    IClicked<TeacherEntity>
{
    public InfoToolStrip[] GetToolStrip(CardClickedToolStripArgs<TeacherEntity>? eventToolStripArgs)
        => [];

    public InfoButton[] GetButtons(ClickedArgs<TeacherManager> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить").CommandClick(() => controlView.LoadView<TeacherAddingPanelViewModel>()),
        ];

    public InfoButton GetButton(CardClickedArgs<TeacherEntity> eventArgs)
        => new InfoButton().CommandClick(() => controlView.LoadView<TeacherAddingPanelViewModel, TeacherEntity>(eventArgs.Entity));
}