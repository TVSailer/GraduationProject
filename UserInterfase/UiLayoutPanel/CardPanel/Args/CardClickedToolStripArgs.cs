namespace UserInterface.UiLayoutPanel.CardPanel.Args;

public class CardClickedToolStripArgs<T>(T entity) : EventArgs
{
    public T Entity { get; init; } = entity;
    public void Deconstruct(out T Entity)
    {
        Entity = this.Entity;
    }
}