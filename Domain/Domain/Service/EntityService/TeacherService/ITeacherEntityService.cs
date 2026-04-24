using Domain.Entitys;
using Domain.ValidObject;

namespace Domain.Service.EntityService.TeacherService;

public interface ITeacherService
{
    public TeacherEntity Add(
        ImageValidObject image,
        NameValidObject name,
        SurnameValidObject surname,
        PatronymicValidObject patronymic,
        DateBirthTeacherValidObject dateBirth,
        NumberPhoneValidObject numberPhone);

    public TeacherEntity Update(TeacherEntity entity);
    public void ExecuteDelete(TeacherEntity teacher);
    public bool CanExecuteDelete(TeacherEntity teacher);
}