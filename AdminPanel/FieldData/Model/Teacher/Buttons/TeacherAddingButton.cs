using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Teacher.Buttons;

public class TeacherAddingButton(
    ControlView controlView, 
    Repository<TeacherEntity> repository) : IButtons<TeacherFieldData>
{
    public List<CustomButton> GetButtons(TeacherFieldData e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Сохранить").CommandClick(() => e.ValidObject((_, entity) =>
            {
                repository.Add(entity, out var logger);
                LogicaMessage.MessageInfo(logger.Log);
                controlView.Exit();
            })),
        ];
}