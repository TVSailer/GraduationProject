namespace UserInterface.Info;

public sealed class InfoButton(string text = "")
{
    public event Action? Click;
    public bool Enabled { get; private set; } = true;
    public string Text { get; private set; } = text;

    public InfoButton CommandClick(Action action)
    {
        Click += action;
        return this;
    }

    public InfoButton Enable(bool enable = true)
    {
        Enabled = enable;
        return this;
    }

    internal void OnClick()
    {
        Click?.Invoke();
    }
}
