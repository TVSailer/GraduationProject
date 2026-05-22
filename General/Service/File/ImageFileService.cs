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
        if (IsFileInAppData(path)) return path;
        Directory.CreateDirectory(_appDataPath);

        var fileName = Guid.NewGuid() + Path.GetExtension(path);
        var destPath = Path.Combine(_appDataPath, fileName);

        System.IO.File.Copy(path, destPath, true);

        return destPath;
    }

    public string GetFullPath(string? fileName)
    {
        if (fileName is null) return "";
        return fileName;
        var fullPath = Path.Combine(_appDataPath, fileName);
        return System.IO.File.Exists(fullPath) ? fullPath : throw new ServiceException("Не найден файл");
    }

    public void DeleteImageFromDisk(string? path)
    {
        if (!IsFileInAppData(path)) return;
        //var fullPath = Path.Combine(_appDataPath, path);

        if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);
    }

    public bool IsFileInAppData(string? path)
    {
        if (path is null) return false;

        //var normalizedFilePath = Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        var normalizedAppDataPath = Path.GetFullPath(_appDataPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        return path.StartsWith(normalizedAppDataPath, StringComparison.OrdinalIgnoreCase);
    }
}