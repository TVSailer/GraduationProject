using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Managment;

public class LessonAddingButton(Repository<LessonEntity> repository, ControlView controlView) : IButtons<ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>>
{
    public List<CustomButton<ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>>> GetButtons(object? data = null)
        => [
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>>()
                .LabelText("Создать расписание")
                .CommandClick((_, e) => new ScheduleView(e.FieldData).ShowDialog()),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>>()
                .LabelText("Сохранить")
                .CommandClick((_, e) => AddEntity(e.FieldData)),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>>()
                .LabelText("Добавить изображение")
                .CommandClick((_, e) => e.FieldData.OnAddingImg.Execute(null)),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>>()
                .LabelText("Удалить изображение")
                .CommandClick((_, e) => e.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>>()
                .LabelText("Назад")
                .CommandClick((_, _) => controlView.Exit()),
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

