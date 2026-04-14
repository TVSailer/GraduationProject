namespace UserInterface.Args;

public class CardClickedToolStripArgs<T>(T data) : EventArgs
{
    public T Data { get; init; } = data;
}