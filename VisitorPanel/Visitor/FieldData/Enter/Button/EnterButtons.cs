using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Visitor.FieldData.Enter.Button;

public class EnterButtons(
    ControlView controlView, 
    AuthRepository authRepository, 
    VisitorsRepository visitorsRepository, 
    MementoVisitor mementoVisitor) : IButtons<EnterDataUi>
{
    public InfoButton[] GetButtons(ClickedArgs<EnterDataUi> eventArgs)
        => [
            new InfoButton("Вход").CommandClick(() =>
            {
                if (authRepository.Verify(eventArgs.Data.Login, eventArgs.Data.Password, out var logger))
                {
                    mementoVisitor.Visitor =
                        visitorsRepository.Get().FirstOrDefault(v => v.AuthEntity.Equals(logger.Auth));
                    controlView.CloseShowDialog();
                    return;
                }
                LogicaMessage.MessageError(logger);
            }),
        ];
}