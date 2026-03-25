using System.Windows.Forms;
using UserInterface.View.Base;

namespace UserInterface.Service.View.Base;

public interface IControlView
{
    public Form Form { get; protected set; }
    public IView<T> LoadView<T>();
    public void UpdateGui();
    public void Exit();
    public void ShowDialog<T>();
    public void CloseDialog();
}