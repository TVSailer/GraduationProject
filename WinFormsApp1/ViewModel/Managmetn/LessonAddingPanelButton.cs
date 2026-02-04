using Admin.Commands_Handlers.Managment;
using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using MediatR;

public class LessonAddingPanelButton(IMediator mediator) : IParametersButtons<LessonAddingPanel>
{
    public List<ButtonInfo> buttons =>
    [
        new("Создать расписание", _ => mediator.Send(new ScheduleLessonRequest())),
        new("Сохранить", _ => mediator.Send(new SaveCommandRequest<LessonAddingPanel, LessonEntity>())),
        new("Добавить изображение", _=> mediator.Send(new ImageRequest(nameof(ViewModelWithImages<>.OnAddingImg)))),
        new("Удалить изображение", _ => mediator.Send(new ImageRequest(nameof(ViewModelWithImages<>.OnDeletingImg)))),
        new("Назад", _ => mediator.Send(new InitializeUI<LessonMangment>()))
    ];
}