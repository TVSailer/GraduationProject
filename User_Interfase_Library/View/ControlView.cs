using System.Windows.Forms;
using UserInterface.Interface;

namespace UserInterface.View;

public class ControlView(IServiceProvision di)
{
    private readonly Stack<UiView> _stack = new();
    public readonly Form Form = new();

    public UiView? View { get; private set; }

    public UiView<T> LoadView<T>(T data)
    {
        if (View is not null) _stack.Push(View);

        var view = di.GetService<UiView<T>>();
        View = view;

        view.SetData(data);
        view.InitializeComponents(Form);

        return view;
    }

    public UiView<T, TEntity> LoadView<T, TEntity>(T data) 
        where TEntity : new()
        where T : IDataUi<TEntity>
    {
        if (View is not null) _stack.Push(View);

        var view = di.GetService<UiView<T, TEntity>>();
        View = view;

        view.SetData(data);
        view.InitializeComponents(Form);

        return view;
    }
    
    public Form UpdateGUI() 
        => View is null ? throw new NullReferenceException() : View.InitializeComponents(Form);
    

    public void Exit()
    {
        View = _stack.Pop();
        UpdateGUI();
    }

    public void ShowDialog<T>() where T : Form
    {
        di.GetService<T>().ShowDialog();
        UpdateGUI();
    }
}