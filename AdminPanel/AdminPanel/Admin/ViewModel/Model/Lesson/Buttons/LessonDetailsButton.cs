using Admin.Args;
using Admin.View;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonDetailsButton(
    ControlView controlView,
    Repository<LessonEntity> repositoryL) : IButtons<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData> e)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Обновить")
                .CommandClick(() => UpdateEntity(e.FieldData)),
            new CustomButton("Добавить изображение")
                .CommandClick(() => e.FieldData.OnAddingImg.Execute(null)),
            new CustomButton("Удалить изображения")
                .CommandClick(() => e.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton("Обновить расписание")
                .CommandClick(() => new ScheduleView(e.FieldData).ShowDialog()),
            new CustomButton("Удалить")
                .CommandClick(() => DeleteEntity(e.FieldData)),
        ];

    private void DeleteEntity(LessonDetailsFieldData arg2FieldData)
    {
        repositoryL.Delete(arg2FieldData.Entity.Id);
        controlView.Exit();
    }



    private void UpdateEntity(LessonDetailsFieldData fieldData)
    {
        if (Validatoreg.TryValidObject(fieldData, out var results))
        {
            repositoryL.Update(fieldData.Entity.Id, fieldData.Entity.GetData());
            controlView.Exit();
        }

        if (fieldData is PropertyChange pc)
            results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
    }
}