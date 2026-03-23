using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Teacher.Buttons;

public class TeacherDetailsButton(
    Repository<TeacherEntity> repository,
    ControlView controlView) : IButtons<TeacherFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<TeacherFieldData> fieldData)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(() =>
            {
                fieldData.Data.ValidObject(repository.Update);
                controlView.Exit();
            }),
            new InfoButton("Удалить").CommandClick(() =>
            {
                if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                if (repository.TryDelete(fieldData.Data.EntityId, out var logger))
                {
                    controlView.Exit();
                    return;
                }

                LogicaMessage.MessageError(logger.Log);
            })
        ];
}