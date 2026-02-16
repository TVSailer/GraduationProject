using Admin.Args;
using Admin.View;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

public class LessonDetailsButton(
    ControlView controlView,
    VisitorsLessonRepository repositoryV,
    Repository<LessonEntity> repositoryL) : IButtons<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>
{
    public List<CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>> GetButtons(object? data = null)
        => [
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>()
                .LabelText("Назад")
                .CommandClick((_, _) => controlView.Exit()),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>()
                .LabelText("Обновить")
                .CommandClick((_, e) => UpdateEntity(e.FieldData)),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>()
                .LabelText("Управление поситителями")
                .CommandClick((_, e) => ControlVisitors(e.FieldData)),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>()
                .LabelText("Управление посещаемостью")
                .CommandClick((_, _) => controlView.Exit()),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>()
                .LabelText("Управление отзывами")
                .CommandClick((_, _) => controlView.Exit()),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>()
                .LabelText("Добавить изображение")
                .CommandClick((_, e) => e.FieldData.OnAddingImg.Execute(null)),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>()
                .LabelText("Удалить изображения")
                .CommandClick((_, e) => e.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>()
                .LabelText("Обновить расписание")
                .CommandClick((_, e) => new ScheduleView(e.FieldData).ShowDialog()),
            new CustomButton<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>()
                .LabelText("Удалить")
                .CommandClick((_, e) => DeleteEntity(e.FieldData)),
        ];

    private void DeleteEntity(LessonDetailsFieldData arg2FieldData)
    {
        repositoryL.Delete(arg2FieldData.Entity.Id);
        controlView.Exit();
    }

    private void ControlVisitors(LessonDetailsFieldData arg2FieldData)
    {
        repositoryV.Lesson = arg2FieldData.Entity.GetData();
        controlView.LoadView<VisitorBelongingLesson>();
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