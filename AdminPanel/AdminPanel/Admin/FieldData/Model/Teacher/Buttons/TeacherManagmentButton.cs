using Admin.DI;
using Admin.DI.Module;
using DataAccess.Postgres.Models;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Teacher.Buttons;

public class TeacherManagerButton(
    ControlView controlView) : 
    IButtons<TeacherManager>,
    IButtons<CardClickedToolStripArgs<TeacherEntity>>, 
    IButton<CardClickedArgs<TeacherEntity>>
{
    public List<CustomButton> GetButtons(CardClickedToolStripArgs<TeacherEntity>? eventToolStripArgs)
        => [];

    public List<CustomButton> GetButtons(TeacherManager eventArgs)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Добавить").CommandClick(() => controlView.LoadView<TeacherFieldData>()),
        ];

    public CustomButton GetButton(CardClickedArgs<TeacherEntity> eventArgs)
        => new CustomButton().CommandClick(() => controlView.LoadView<TeacherFieldData, TeacherEntity>(eventArgs.Entity));
}