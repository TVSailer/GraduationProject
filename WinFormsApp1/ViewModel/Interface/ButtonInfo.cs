namespace Admin.ViewModel.Managment;

public record ButtonInfo(string LabelText, Action<Button> Command, Func<Button, bool>? Enabled = null);
