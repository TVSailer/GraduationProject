using Domain.Valid.AttributeValid;

namespace Admin.ViewModel.Model.Teacher;

public class TeacherAddingPanelViewModel : General.ViewModel.ViewModel
{
    [Name] public string? Name { get; set => Set(ref field, value); }
    [Surname] public string? Surname { get; set => Set(ref field, value); }
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); }
    [DateBirthday] public string? DateBirth { get; set => Set(ref field, value); }
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); }

    //repository.Add(entity, out var logger);
    //LogicaMessage.MessageInfo(logger.Log);
    //controlView.Exit();
}