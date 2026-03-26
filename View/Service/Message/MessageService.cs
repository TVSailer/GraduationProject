using Domain.Enum;
using Domain.Service.MessageService.BaseMessageService;
using UserInterface.Message;

namespace General.Service.Message;

public class MessageService : IMessageService
{
    public void Message(string text, TypeMessage typeMessage)
    {
        switch (typeMessage)
        {
            case TypeMessage.Error:
                LogicaMessage.MessageError(text);
                break;
            case TypeMessage.Info:
                LogicaMessage.MessageInfo(text);
                break;
            case TypeMessage.Warning:
                LogicaMessage.MessageWarning(text);
                break;
            case TypeMessage.YesNo:
                LogicaMessage.MessageYesNo(text);
                break;
            case TypeMessage.YesCancel:
                LogicaMessage.MessageOkCancel(text);
                break;
            default:
                throw new ArgumentException();
        }
        
    }
}