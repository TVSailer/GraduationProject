using Domain.Entitys;
using Domain.Enum;
using Domain.Exception;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.MessageService.BaseMessageService;
using Domain.ValidObject;

namespace Domain.Service.EntityService.TeacherService;

public class TeacherService(IRepository<TeacherEntity> repositoryT, IAuthService authService, IMessageService messageService) : ITeacherService
{
    public TeacherEntity Add(
        ImageValidObject image, 
        NameValidObject name, 
        SurnameValidObject surname,
        PatronymicValidObject patronymic, 
        DateBirthTeacherValidObject dateBirth, 
        NumberPhoneValidObject numberPhone)
    {
        var auth = authService.CreateAuth(surname.Text, UserRole.Teacher);
        var teacher = repositoryT.Add(new TeacherEntity(image, name, surname, patronymic, dateBirth, numberPhone, auth));
        authService.MessageAuth();

        return teacher;
    }

    public TeacherEntity Update(
        TeacherEntity entity)
    {
        authService.UpdateAuth(entity.AuthEntity);
        repositoryT.Update(entity);
        authService.MessageAuth();

        return entity;
    }

    public void ExecuteDelete(TeacherEntity teacher)
    {
        if (teacher.Lessons is not { Count: 0 })
            throw new ServiceException("Для удаления преподователь не должен вести ни каких урков!");

        repositoryT.Delete(teacher.Id);
        authService.Delete(teacher.AuthEntity);
    }

    public bool CanExecuteDelete(TeacherEntity teacher)
    {
        if (teacher.Lessons is not { Count: 0 })
        {
            messageService.Message("Для удаления преподователь не должен вести ни каких урков!", TypeMessage.Error);
            return false;
        }
        return messageService.Message("Вы дейсвительно хотите удалть?", TypeMessage.YesCancel) is TypeCommandMessage.Yes;
    }
}