using Domain.ValidObject;

namespace Domain.Service.MessageService.BaseMessageService;

public interface IMessageAuthDataService
{
    public void Message(LoginValidObject login, PasswordValidObject password);
}