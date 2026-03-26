using Domain.Enum;

namespace Domain.Service.MessageService.BaseMessageService;

public interface IMessageService
{
    public TypeCommandMessage Message(string text, TypeMessage typeMessage);
}