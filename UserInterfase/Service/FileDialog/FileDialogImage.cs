using System.Windows.Forms;
using CSharpFunctionalExtensions;
using UserInterface.Service.FileDialog.BaseFileDialog;

namespace UserInterface.Service.FileDialog;

public class ImageDialogService : IImageDialogService
{
    private const string TitleManager = "Выберите изображения мероприятия";
    private const string FilesPictureBox = "Выберите изображения PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

    public string[]? ShowOpenFileDialog(bool multiselect = true)
    {
        using var openFileDialog = new OpenFileDialog()
        {
            Filter = FilesPictureBox,
            Title = TitleManager,
            Multiselect = multiselect
        };
        return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileNames : null;
    }

    public bool ShowConfirmDialog(string message)
    {
        return MessageBox.Show(message, "Подтверждение",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }
}