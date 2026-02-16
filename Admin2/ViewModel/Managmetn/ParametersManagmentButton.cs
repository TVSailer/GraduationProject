using Admin.Args;
using Admin.View;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

public class BaseManagmentButton<T, TEntity, TAddingPanel>(ControlView controlView) : IButtons<ViewButtonClickArgs<T>>
    where TEntity : Entity, new()
    where TAddingPanel : IFieldData<TEntity>
    where T : IFieldData
{
    public List<CustomButton<ViewButtonClickArgs<T>>> GetButtons(object? data = null)
        => [
            new CustomButton<ViewButtonClickArgs<T>>()
                .LabelText("Назад")
                .CommandClick((_, _) => controlView.Exit()),
            new CustomButton<ViewButtonClickArgs<T>>()
                .LabelText("Добавить")
                .CommandClick((_, _) => controlView.LoadView<TAddingPanel>()),
        ];
}