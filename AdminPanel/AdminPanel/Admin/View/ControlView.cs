using Admin.Memento;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica.Interface;

namespace Admin.View;

public class ControlView(MementoView mementoView, IServiceProvision di)
{
    public Form Form { get; } = new();
    public IView? View { get; private set; }

    public IView<T> LoadView<T>(object? data = null)
    {
        if (View is not null) mementoView.Push(View);

        View = di.GetService<IView<T>>();
        View.InitializeComponents(Form);
        return (IView<T>)View;
    }

    public IView<T, TEntity> LoadView<T, TEntity>(TEntity entity, object? data = null) 
        where TEntity : Entity, new()
        where T : IFieldData<TEntity>
    {
        if (View is not null) mementoView.Push(View);

        var view = di.GetService<IView<T, TEntity>>();
        view.ViewField.Entity.SetEntity(entity);
        View = view;
        View.InitializeComponents(Form);
        return (IView<T, TEntity>)View;
    }

    public void UpdateGUI(object? data = null) => View.InitializeComponents(Form);

    public Form Exit(object? data = null)
    {
        View = mementoView.Pop();
        return View.InitializeComponents(Form);
    }
}