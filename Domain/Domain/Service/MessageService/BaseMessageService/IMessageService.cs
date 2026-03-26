using Domain.Enum;

namespace Domain.Service.MessageService.BaseMessageService;

public interface IMessageService
{
    public void Message(string text, TypeMessage typeMessage);
}