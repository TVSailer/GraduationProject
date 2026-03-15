namespace UserInterface.UiLayoutPanel.CardPanel.Args;

public class CardClickedToolStripArgs<T>(T data) : EventArgs
{
    public T Data { get; init; } = data;
    public void Deconstruct(out T Entity)
    {
        Entity = this.Data;
    }
}