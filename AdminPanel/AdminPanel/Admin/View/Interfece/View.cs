using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica.Interface;

namespace Admin.View.ViewForm;

public abstract class View<T> : View, IView<T>;

public abstract class View<T, TEntity>(T fieldData) : View, IView<T, TEntity>
    where TEntity : Entity, new()
    where T : IFieldData<TEntity>
{
    public T ViewField { get; set; } = fieldData;
}

public abstract class View : IView
{
    public virtual Form InitializeForm(Form form)
    {
        return form;
    }

    public Form InitializeComponents(Form form)
    {
        return form
            .With(m => m.Controls.Clear())
            .With(m => InitializeForm(m))
            .With(m => m.Controls.Add(CreateUi()));
    }

    protected abstract Control? CreateUi();
}