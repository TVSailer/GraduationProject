using Admin.Commands_Handlers.Managment;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using MediatR;

namespace Admin.ViewModel.Managmetn;

public class LessonAddingPanelButton(Repository<LessonEntity> repository) : IParametersButtons<LessonAddingPanelUI>
{
    public List<ButtonInfo> GetButtons(LessonAddingPanelUI instance)
        =>
        [
            new("Создать расписание", _ => new ScheduleView(instance).ShowDialog()),
            new("Сохранить", _ =>
            {
                if (Validatoreg.TryValidObject(instance, out var results))
                {
                    repository.Add(instance.Entity.GetEntity());
                    AdminDI.GetService<IView<LessonMangment>>().InitializeComponents(null);
                }

                if (instance is PropertyChange pc)
                    results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
            }),
            new("Добавить изображение", _ => instance.OnAddingImg.Execute(null)),
            new("Удалить изображение", _ => instance.OnDeletingImg.Execute(null)),
            new("Назад", _ => AdminDI.GetService<IView<LessonMangment>>().InitializeComponents(null))
        ];
}

