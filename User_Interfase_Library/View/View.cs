using System.Windows.Forms;
using UserInterface.Interface;
using UserInterface.LayoutPanel;

namespace UserInterface.View;

public abstract class UiView<T>(T data) : UiView
{
    public readonly T DataUi = data;
}

public abstract class UiView<T, TEntity>(T dataUi) : UiView<T>(dataUi) where TEntity : new()
    where T : IDataUi<TEntity>
{
    public new readonly IDataUi<TEntity> DataUi = dataUi;
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