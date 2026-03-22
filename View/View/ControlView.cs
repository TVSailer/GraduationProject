using System.Windows.Forms;
using AbstractView.View;
using Domain.DIService;

namespace Abstract.View;

public class ControlView(IServiceProvision di)
{
    private readonly Stack<UiView> _stack = new();
    public readonly Form Form = new();

    private Form? _showDialogForm;
    public UiView? View { get; private set; }

    public UiView LoadView<T>()
        where T : UiView
    {
        if (View is not null) _stack.Push(View);

        var view = di.GetService<T>();
        View = view;

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
        _showDialogForm = di.GetService<T>();
        _showDialogForm.ShowDialog();
        UpdateGUI();
    }

    public void CloseShowDialog() => _showDialogForm?.Close();
}