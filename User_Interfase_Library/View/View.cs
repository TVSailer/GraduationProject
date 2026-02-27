using System.Windows.Forms;
using Extension_Func_Library;
using User_Interface_Library.Interface;

namespace User_Interface_Library.View;

public abstract class UiView<T> : UiView
{
}

public abstract class UiView<T, TEntity> : UiView<T>
    where TEntity : new()
    where T : IDataUi<TEntity>
{
}

public abstract class UiView
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