using Domain.Enum;
using Domain.Service.MessageService.BaseMessageService;
using UserInterface.Message;

namespace General.Service.Message;

public class MessageService : IMessageService
{
    public TypeCommandMessage Message(string text, TypeMessage typeMessage)
    {
        switch (typeMessage)
        {
            case TypeMessage.Error:
                LogicaMessage.MessageError(text);
                return TypeCommandMessage.Ok;
            case TypeMessage.Info:
                LogicaMessage.MessageInfo(text);
                return TypeCommandMessage.Ok;
            case TypeMessage.Warning:
                LogicaMessage.MessageWarning(text);
                return TypeCommandMessage.Ok;
            case TypeMessage.YesNo:
                if (LogicaMessage.MessageYesNo(text))
                    return TypeCommandMessage.Yes;
                return TypeCommandMessage.No;
            case TypeMessage.YesCancel:
                if (LogicaMessage.MessageOkCancel(text))
                    return TypeCommandMessage.Yes;
                return TypeCommandMessage.Cancel;
            default:
                throw new ArgumentException();
        }
        
    }
}