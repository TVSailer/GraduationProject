using Admin.Args;
using Admin.View;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica.Interface;
using Logica.UI;

public class BaseManagmentButton<T, TEntity, TAddingPanel>(ControlView controlView) : IButtons<ViewButtonClickArgs<T>>
    where TEntity : Entity, new()
    where TAddingPanel : IFieldData<TEntity>
    where T : IFieldData
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<T> e)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Добавить")
                .CommandClick(() => controlView.LoadView<TAddingPanel>()),
        ];
}