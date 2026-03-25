using System.Windows.Forms;
using UserInterface.DIService;
using UserInterface.Service.View.Base;
using UserInterface.View.Base;

namespace UserInterface.Service.View;

public class ControlView(IServiceProvisionUI di) : IControlView
{
    private readonly Stack<IView> _stack = new();
    public Form Form { get; set; } = new();

    private IForma? _showDialogForm;
    private IView? _view { get; set; }

    public IView<T> LoadView<T>()
    {
        if (_view is not null) _stack.Push(_view);

        var view = di.GetService<IView<T>>();
        _view = view;

        view.InitializeComponents(Form);

        return view;
    }

    public void UpdateGui()
    {
        if (_view is null) throw new NullReferenceException();
        _view.InitializeComponents(Form);
    }

    public void Exit()
    {
        if (!_stack.TryPop(out var view))
        {
            Form.Close();
            return;
        }
        _view = view;
        UpdateGui();
    }

    public void ShowDialog<T>()
    {
        _showDialogForm = di.GetService<IForma<T>>();
        _showDialogForm.ShowDialog();
        UpdateGui();
    }

    public void CloseDialog() => _showDialogForm?.Close();
}