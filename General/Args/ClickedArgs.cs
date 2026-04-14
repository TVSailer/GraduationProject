namespace UserInterface.Args;

public class ClickedArgs<T>(T data) : EventArgs
{
    public T Data { get; init; } = data;
}