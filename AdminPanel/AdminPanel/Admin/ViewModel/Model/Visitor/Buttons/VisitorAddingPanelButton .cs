using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorAddingButton(MementoLesson mementoLesson, ControlView controlView) : IButtons<ViewButtonClickArgs<VisitorEntity, VisitorAddingFieldData>>
{
    public List<CustomButton> GetButtons(
        object? data, ViewButtonClickArgs<VisitorEntity, VisitorAddingFieldData>? e)
        => [
            new CustomButton("Назад")
                .CommandClick(controlView.Exit),
            new CustomButton("Сохранить")
                .CommandClick(() => e?.FieldData.TryWordWithEntity(entity =>
                {
                    mementoLesson.AddVisitor(entity.GetDataNotNull());
                    controlView.Exit();
                })),
        ];
}