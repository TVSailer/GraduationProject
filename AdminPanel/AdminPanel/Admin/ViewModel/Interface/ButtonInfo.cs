namespace Admin.ViewModel.Interface;

public sealed class CustomButton : Button
{
    public CustomButton(string? text = "")
    {
        Dock = DockStyle.Fill;
        Text = text;
        Font = new Font("Times New Roman", 11, FontStyle.Bold);
    }
    public CustomButton CommandClick(Action action) => this.With(b => Click += (s, e) => action());
    public CustomButton NoEnabled() => this.With(_ => Enabled = false);
    public CustomButton Enablede(bool enable = true) => this.With(_ => Enabled = enable);
}
