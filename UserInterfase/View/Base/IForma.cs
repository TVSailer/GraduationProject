using UserInterface.LayoutPanel;

namespace UserInterface.View.Base;

public interface IForma<T> : IForma;

public interface IForma
{
    public void ShowDialog();
    public void Initialize();
    public void Close();
    public IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel);
}