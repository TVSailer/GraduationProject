using Admin.Args;
using Admin.View;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Managment;

public class LessonAddingButton(Repository<LessonEntity> repository, ControlView controlView) : IButtons<ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>? e)
        => [
            new CustomButton("Создать расписание")
                .CommandClick(() => new ScheduleView(e.FieldData).ShowDialog()),
            new CustomButton("Сохранить")
                .CommandClick(() => AddEntity(e.FieldData)),
            new CustomButton("Добавить изображение")
                .CommandClick(() => e.FieldData.OnAddingImg.Execute(null)),
            new CustomButton("Удалить изображение")
                .CommandClick(() => e.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
        ];

    private void AddEntity(LessonAddingFieldData fieldData)
    {
        if (Validatoreg.TryValidObject(fieldData, out var results))
        {
            repository.Add(fieldData.Entity.GetData());
            controlView.Exit();
        };

        if (fieldData is PropertyChange pc)
            results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
    }
}

