namespace UserInterface.Info;

public sealed class InfoToolStrip(string text)
{
    public event Action? Click;
    public string Text { get; private set; } = text;

    public InfoToolStrip CommandClick(Action action)
    {
        Click += action;
        return this;
    }

    public void OnClick()
    {
        Click?.Invoke();
    }
}