namespace UserInterface.Info
{
    public sealed class InfoLinkLabel(string text)
    {
        public event Action? Click;
        public string Text { get; private set; } = text;
        public bool Enabled { get; private set; } = true;

        public InfoLinkLabel CommandClick(Action action)
        {
            Click += action;
            return this;
        }

        public InfoLinkLabel Enable(bool enable = true)
        {
            Enabled = enable;
            return this;
        }

        public void OnClick()
        {
            Click?.Invoke();
        }
    }
}