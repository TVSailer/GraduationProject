using Admin.Commands_Handlers.Managment;
using Admin.Memento;
using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using MediatR;

public class ManagmentButton<T, TEntity, TAddingPanel>(ControlView view) : IParametersButtons<T>
    where TEntity : Entity, new()
    where TAddingPanel : IFieldData<TEntity>
{
    public List<ButtonInfo> GetButtons(T instance)
    => 
    [
        new("Назад", _ => view.Exit()),
        new("Добавить", _ => view.LoadView<TAddingPanel>())
    ];
}