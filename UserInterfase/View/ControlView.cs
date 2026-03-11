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
    
    public UiView<T> LoadView<T>()
    {
        if (View is not null) _stack.Push(View);

        var view = di.GetService<UiView<T>>();
        var dataUi = di.GetService<T>();
        View = view;

        view.SetData(dataUi);
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
    
    public UiView<T, TEntity> LoadView<T, TEntity>(TEntity data) 
        where TEntity : new()
        where T : IDataUi<TEntity>
    {
        if (View is not null) _stack.Push(View);

        var view = di.GetService<UiView<T, TEntity>>();
        var dataUi = di.GetService<T>();
        View = view;

        dataUi.Entity = data;
        view.SetData(dataUi);
        view.InitializeComponents(Form);

        return view;
    }
    
    public void UpdateGUI()
    {
        if (View is null) throw new NullReferenceException();
        View.InitializeComponents(Form);
    }


    public void Exit()
    {
        if (!_stack.TryPop(out var view))
        {
            Form.Close();
            return;
        }
        View = view;
        UpdateGUI();
    }

    public void ShowDialog<T>() where T : Form
    {
        di.GetService<T>().ShowDialog();
        UpdateGUI();
    }
}