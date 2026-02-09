using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.Memento;

public class MementoView
{
    private readonly Stack<IView> stack= new();

    public void Push(IView view) => stack.Push(view);
    public IView Pop() => stack.Pop();
}