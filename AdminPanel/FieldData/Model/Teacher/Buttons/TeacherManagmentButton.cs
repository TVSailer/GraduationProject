using Admin.DI;
using Admin.DI.Module;
using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Teacher.Buttons;

public class TeacherManagerClicked(
    ControlView controlView) : 
    IButtons<TeacherManager>,
    IButtons<CardClickedToolStripArgs<TeacherEntity>>, 
    IClicked<CardClickedArgs<TeacherEntity>>
{
    public List<InfoButton> GetButtons(CardClickedToolStripArgs<TeacherEntity>? eventToolStripArgs)
        => [];

    public List<InfoButton> GetButtons(TeacherManager eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить").CommandClick(() => controlView.LoadView<TeacherFieldData>()),
        ];

    public InfoButton GetButton(CardClickedArgs<TeacherEntity> eventArgs)
        => new InfoButton().CommandClick(() => controlView.LoadView<TeacherFieldData, TeacherEntity>(eventArgs.Entity));
}