using Admin.Memento;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.View;

public class ControlView(MementoView mementoView, IServiceProvision di)
{
    public IView? View { get; private set; }

    public Form LoadView<T>(object? data = null)
    {
        if (View is not null) mementoView.Push(View);

        View = di.GetService<IView<T>>();
        return View.InitializeComponents(data);
    }
    
    public Form LoadView<T, TEntity>(TEntity entity, object? data = null) 
        where TEntity : Entity, new()
        where T : IFieldData<TEntity>
    {
        if (View is not null) mementoView.Push(View);

        var view = di.GetService<IView<T, TEntity>>();
        view.ViewField.Entity.SetEntity(entity);
        View = view;
        return View.InitializeComponents(data);
    }
    
    public Form Exit(object? data = null)
    {
        View = mementoView.Pop();
        return View.InitializeComponents(data);
    }
}