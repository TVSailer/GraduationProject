using Domain.Enum;
using Domain.Service.MessageService.BaseMessageService;
using Domain.ValidObject;

namespace Domain.Service.MessageService;

public class MessageAuthDataService(IMessageService messageService) : IMessageAuthDataService
{
    public void Message(LoginValidObject login, PasswordValidObject password)
    {
        messageService.Message(
            $"Логин: {login.Login}" +
            $"\n" +
            $"Пароль: {password.Password}", TypeMessage.Info);
    }
}