using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ExtensionFunc;

namespace UserInterface.UiObjects.Image;

public class ImgUi : PictureBox
{
    public readonly string Url;
    private Bitmap _originalImage;
    private Bitmap _scaledImage;
    private bool _isSelected;

    public ImgUi(string url)
    {
        Url = url;
        Size = new Size(100, 100); // Временный размер, пока грузится
        Margin = new Padding(5);
        SizeMode = PictureBoxSizeMode.Zoom;

        MouseDoubleClick += (_, _) => FullSizeImage();
        MouseClick += async (_, _) => await ToggleSelection();

        var path = Path.Combine(Directory.GetCurrentDirectory(), "Resource", "BackgroundImage2.png");

        BackgroundImage = new Bitmap(path);

        // Асинхронная загрузка и масштабирование
        _ = LoadImageAsync(url, 300);
    }

    private async Task LoadImageAsync(string url, int targetHeight)
    {
        try
        {
            // Загружаем и масштабируем изображение в фоне
            var scaledImage = await ScaleImageByHeightAsync(url, targetHeight);
            if (scaledImage is null) return;
            // Возвращаемся в UI поток для обновления контрола
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    _scaledImage = scaledImage;
                    Image = scaledImage;
                    Size = new Size(scaledImage.Width, scaledImage.Height);
                });
            }
            else
            {
                _scaledImage = scaledImage;
                Image = scaledImage;
                Size = new Size(scaledImage.Width, scaledImage.Height);
            }
        }
        catch (Exception ex)
        {
            // Обработка ошибок загрузки
            Debug.WriteLine($"Ошибка загрузки изображения: {ex.Message}");
        }
    }

    private async Task ToggleSelection()
    {
        _isSelected = !_isSelected;

        if (_isSelected)
        {
            var darkenedImage = await DarkenImageAsync(_scaledImage);
            Image = darkenedImage;
        }
        else Image = _scaledImage;
    }

    public async Task<Bitmap?> ScaleImageByHeightAsync(string url, int targetHeight)
    {
        return await Task.Run(() =>
        {
            if (!File.Exists(url))
            {
                Debug.WriteLine("Такого файла нет");
                return null;
            }
            using var originalImage = new Bitmap(url);
            double scale = (double)targetHeight / originalImage.Height;
            int targetWidth = (int)(originalImage.Width * scale);

            Bitmap scaledImage = new Bitmap(targetWidth, targetHeight);

            using Graphics g = Graphics.FromImage(scaledImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);

            return scaledImage;
        });
    }

    private async Task<Bitmap> DarkenImageAsync(System.Drawing.Image original)
    {
        return await Task.Run(() =>
        {
            Bitmap result = new Bitmap(original.Width, original.Height);

            using Graphics g = Graphics.FromImage(result);
            g.DrawImage(original, 0, 0, original.Width, original.Height);

            using Brush darkBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
            g.FillRectangle(darkBrush, 0, 0, original.Width, original.Height);

            return result;
        });
    }

    private void FullSizeImage()
    {
        new Form()
            .With(f => f.Text = $@"Просмотр изображения: {Path.GetFileName(Url)}")
            .With(f => f.Size = new Size(800, 600))
            .With(f => f.StartPosition = FormStartPosition.CenterParent)
            .With(f => f.BackColor = Color.Black)
            .With(f => f.Controls.Add(
                new PictureBox()
                    .With(pb => pb.Dock = DockStyle.Fill)
                    .With(pb => pb.SizeMode = PictureBoxSizeMode.Zoom)
                    .With(pb => pb.ImageLocation = Url)))
            .ShowDialog();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _scaledImage?.Dispose();
            _originalImage?.Dispose();
        }
        base.Dispose(disposing);
    }
}