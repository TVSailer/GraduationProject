using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Teacher.Buttons;

public class TeacherAddingButton(
    ControlView controlView, 
    Repository<TeacherEntity> repository) : IButtons<TeacherFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<TeacherFieldData> e)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Сохранить").CommandClick(() => e.Data.ValidObject((_, entity) =>
            {
                repository.Add(entity, out var logger);
                LogicaMessage.MessageInfo(logger.Log);
                controlView.Exit();
            })),
        ];
}