using Admin.Commands_Handlers.Managment;using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using MediatR;

public class ParametersManagmentButton<T, TEntity, TExit, TAddingPanel>(IServiceProvision di) : IParametersButtons<T>
    where TEntity : Entity, new()
    where TAddingPanel : IFieldData<TEntity>
{
    public List<ButtonInfo> GetButtons(T instance)
    => 
    [
        new("Назад", _ => di.GetService<IView<TExit>>().InitializeComponents(null)),
        new("Добавить", _ => di.GetService<IView<TAddingPanel, TEntity>>().InitializeComponents(null))
    ];
}