namespace UserInterface.Args;

public class CardClickedArgs<T>(T entity) : EventArgs
{
    public T Entity { get; init; } = entity;
}