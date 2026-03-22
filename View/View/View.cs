using System.Windows.Forms;
using UserInterface.LayoutPanel;

namespace AbstractView.View;

public abstract class UiView
{
    protected virtual Form InitializeForm(Form form)
    {
        return form;
    }

    internal Form InitializeComponents(Form form)
    {
        form.Controls.Clear();
        InitializeForm(form);
        form.Controls.Add(CreateUi(new BuilderLayoutPanel()).Build());
        return form;

    }

    protected abstract IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel);
}

