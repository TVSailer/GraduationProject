namespace UserInterface.Info
{
    public sealed class InfoLinkLabel(string text)
    {
        public event Action? Click;
        public string Text { get; private set; } = text;

        public InfoLinkLabel CommandClick(Action action)
        {
            Click += action;
            return this;
        }

        public void OnClick()
        {
            Click?.Invoke();
        }
    }
}