using System.Windows.Forms;
using UserInterface.LayoutPanel;
using UserInterface.View.Base;

namespace UserInterface.View;

public abstract class UiView<T> : IView<T>, IViewBuilder
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

    public abstract IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel);
}

