using System.Windows.Forms;
using UserInterface.Interface;
using UserInterface.LayoutPanel;

namespace UserInterface.View;

public abstract class UiView<T> : UiView
{
    public T DataUi { get; private set; } = default!;
    public virtual void SetData(T data)
    {
        DataUi = data;
    }
}

public abstract class UiView<T, TEntity> : UiView<T> where TEntity : new()
    where T : IDataUi<TEntity>
{
    public new T DataUi { get; private set; } = default!;

    public override void SetData(T data)
    {
        DataUi = data;
    }
}

public abstract class UiView
{
    public virtual Form InitializeForm(Form form)
    {
        return form;
    }

    public Form InitializeComponents(Form form)
    {
        form.Controls.Clear();
        InitializeForm(form);
        form.Controls.Add(CreateUi(new BuilderLayoutPanel()).Build());
        return form;

    }

    protected abstract IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel);
}