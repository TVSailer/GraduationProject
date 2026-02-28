using System.Windows.Forms;
using UserInterface.Interface;

namespace UserInterface.View;

public class ControlView(IServiceProvision di)
{
    private readonly Stack<UiView> stack = new();
    public readonly Form Form = new();

    public UiView? View { get; private set; }

    public UiView<T> LoadView<T>()
    {
        if (View is not null) stack.Push(View);

        View = di.GetService<UiView<T>>();
        View.InitializeComponents(Form);
        return (UiView<T>)View;
    }

    public UiView<T, TEntity> LoadView<T, TEntity>() 
        where TEntity : new()
        where T : IDataUi<TEntity>
    {
        if (View is not null) stack.Push(View);

        View = di.GetService<UiView<T, TEntity>>();
        View.InitializeComponents(Form);
        return (UiView<T, TEntity>)View;
    }
    
    public Form UpdateGUI() 
        => View is null ? throw new NullReferenceException() : View.InitializeComponents(Form);
    

    public void Exit()
    {
        View = stack.Pop();
        UpdateGUI();
    }

    public void ShowDialog<T>() where T : Form
    {
        di.GetService<T>().ShowDialog();
        UpdateGUI();
    }
}