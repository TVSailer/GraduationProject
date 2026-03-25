namespace UserInterface.Service.FileDialog.BaseFileDialog;

public interface IImageDialogService
{
    public string[]? ShowOpenFileDialog(bool multiselect = true);
    bool ShowConfirmDialog(string message);
}