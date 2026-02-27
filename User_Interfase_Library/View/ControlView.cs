using System.Windows.Forms;
using User_Interface_Library.Interface;

namespace User_Interface_Library.View;

public class ControlView(IServiceProvision di)
{
    private readonly Stack<UiView> stack = new();

    public Form Form { get; } = new();
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
        where T : IFieldData<TEntity>
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