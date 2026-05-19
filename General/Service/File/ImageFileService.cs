using Domain.Exception;
using Domain.Service.FielService.BaseFileService;
using System.Windows.Forms;

namespace General.Service.File;

public class ImageFileService : IImageFileService
{
    private const string TitleManager = "Выберите изображения мероприятия";
    private const string FilesPictureBox = "Выберите изображения PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
    private const string NameMainFolder = "AdminPanel";
    private const string NameImageFolder = "Images";

    private readonly string _appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), NameMainFolder, NameImageFolder);

    public IEnumerable<string> SaveImagesToDisk(IEnumerable<string>? paths) 
        => paths?.Select(SaveImageToDick);

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

    public string SaveImageToDick(string? path)
    {
        if (path is null) throw new ServiceException("Передаваемое значение не может быть пустым");
        if (IsFileInAppData(path)) return Path.GetFileName(path);
        Directory.CreateDirectory(_appDataPath);

        var fileName = Guid.NewGuid() + Path.GetExtension(path);
        var destPath = Path.Combine(_appDataPath, fileName);

        System.IO.File.Copy(path, destPath, true);

        return fileName;
    }

    public string GetFullPath(string? fileName)
    {
        if (fileName is null) return "";
        var fullPath = Path.Combine(_appDataPath, fileName);
        return System.IO.File.Exists(fullPath) ? fullPath : throw new ServiceException("Не найден файл");
    }

    public void DeleteImageFromDisk(string? fileName)
    {
        if (!IsFileInAppData(fileName)) return;
        var fullPath = Path.Combine(_appDataPath, fileName);

        if (System.IO.File.Exists(fullPath))
            System.IO.File.Delete(fullPath);
    }

    public bool IsFileInAppData(string? filePath)
    {
        if (filePath is null) return false;

        var normalizedFilePath = Path.GetFullPath(filePath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        var normalizedAppDataPath = Path.GetFullPath(_appDataPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        return normalizedFilePath.StartsWith(normalizedAppDataPath, StringComparison.OrdinalIgnoreCase);
    }
}