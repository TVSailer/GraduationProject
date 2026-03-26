using Domain.Valid.AttributeValid;

namespace Admin.ViewModel.Model.Teacher;

public class TeacherDetailsPanelViewModel : General.ViewModel.ViewModel
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

//new InfoButton("Назад").CommandClick(controlView.Exit),
//new InfoButton("Обновить").CommandClick(() =>
//{
//    fieldData.Data.ValidObject(repository.Update);
//    controlView.Exit();
//}),
//new InfoButton("Удалить").CommandClick(() =>
//{
//    if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
//    if (repository.TryDelete(fieldData.Data.EntityId, out var logger))
//    {
//        controlView.Exit();
//        return;
//    }

//    LogicaMessage.MessageError(logger.Log);
//})