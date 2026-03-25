using System.Windows.Forms;

namespace UserInterface.View.Base;

public interface IView<T> : IView
{
}

public interface IView
{
    internal Form InitializeComponents(Form form);
}