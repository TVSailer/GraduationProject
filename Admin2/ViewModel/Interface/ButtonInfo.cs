namespace Admin.ViewModel.Interface;

public sealed class CustomButton<TEventArgs> : CustomButton
{
    private Action<object?, TEventArgs> _command;

    public CustomButton<TEventArgs> CommandClick(Action<object?, TEventArgs> action) => this.With(b => _command = action);
    public new CustomButton<TEventArgs> LabelText(string text) => this.With(b => base.LabelText(text));
    public new CustomButton<TEventArgs> Enablede(bool enable = true) => this.With(_ => base.Enablede(enable));

    public CustomButton<TEventArgs> OnClick(object? send, TEventArgs eventArgs)
    {
        Click += (s, e) => _command(send, eventArgs);
        return this;
    }
}

public class CustomButton : Button
{
    public CustomButton()
    {
        Dock = DockStyle.Fill;
        Font = new Font("Times New Roman", 11, FontStyle.Bold);
    }

    public CustomButton LabelText(string text) => this.With(b => b.Text = text);
    public CustomButton NoEnabled() => this.With(_ => base.Enabled = false);
    public new CustomButton Enablede(bool enable = true) => this.With(_ => base.Enabled = enable);
}
