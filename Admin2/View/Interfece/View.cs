using Admin.View.AdminMain;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.View.ViewForm;

public abstract class View<T>(AdminMainView form) : View(form), IView<T>
{
}

public abstract class View<T, TEntity>(AdminMainView form, T fieldData) : View(form), IView<T, TEntity>
    where TEntity : Entity, new()
    where T : IFieldData<TEntity>
{
    public T ViewField { get; set; } = fieldData;
}

public abstract class View(AdminMainView form) : IView
{
    protected object? data;

    public Form InitializeComponents(object? data)
    {
        this.data = data;

        return form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(CreateUi()));
    }

    protected abstract Control? CreateUi();
}