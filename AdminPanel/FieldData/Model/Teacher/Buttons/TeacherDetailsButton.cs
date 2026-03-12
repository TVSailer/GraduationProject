using DataAccess.Postgres;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Teacher.Buttons;

public class TeacherDetailsButton(
    Repository<TeacherEntity> repository,
    ControlView controlView) : IButtons<TeacherFieldData>
{
    public List<InfoButton> GetButtons(TeacherFieldData fieldData)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(() =>
            {
                fieldData.ValidObject(repository.Update);
                controlView.Exit();
            }),
            new InfoButton("Удалить").CommandClick(() =>
            {
                if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                if (repository.TryDelete(fieldData.EntityId, out var logger))
                {
                    controlView.Exit();
                    return;
                }

                LogicaMessage.MessageError(logger.Log);
            })
        ];
}