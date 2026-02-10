using Admin.View;
using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Managmetn;

public class LessonAddingPanelButton(Repository<LessonEntity> repository, ControlView view) : IParametersButtons<LessonAddingPanelUI>
{
    public List<ButtonInfo> GetButtons(LessonAddingPanelUI instance)
        =>
        [
            new("Создать расписание", _ => new ScheduleView(instance).ShowDialog()),
            new("Сохранить", _ =>
            {
                if (Validatoreg.TryValidObject(instance, out var results))
                {
                    repository.Add(instance.Entity.GetData());
                    view.Exit();
                };

                if (instance is PropertyChange pc)
                    results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
            }),
            new("Добавить изображение", _ => instance.OnAddingImg.Execute(null)),
            new("Удалить изображение", _ => instance.OnDeletingImg.Execute(null)),
            new("Назад", _ => view.Exit())
        ];
}

