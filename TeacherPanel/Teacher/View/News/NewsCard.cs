using System.ComponentModel;
using System.Runtime.CompilerServices;
using Domain.Entitys;
using Domain.Service.DebugService;
using Domain.Service.FielService.BaseFileService;
using Domain.ValidObject;
using General.Service.DebugService;
using General.Service.File;
using General.Service.Message;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiObjects.Card;

namespace Teacher.View.News;

public class NewsCard : ObjectCard<NewsEntity>, INotifyPropertyChanged
{
    private readonly IImageFileService _imageFileService;
    public event PropertyChangedEventHandler? PropertyChanged;
    public List<string> Images { get; set; } = [];


    public NewsCard()
    {
        Height = 500;
        Dock = DockStyle.Top;
        Margin = new Padding(5);

        _imageFileService = new ImageFileService(
            new YandexDiskDebugLogService(
                new DebugLogService()),
            new MessageService(),
            new DebugLogService());
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
    {
        var b = builderLayoutPanel.Row()
        .Column(48)
            .RowAutoSize().Content()
                .Label(Entity.Title)
                .Size(14)
                .ForeColor(Color.DarkBlue)
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Date)
                .Size(12)
               .ForeColor(Color.Gray)
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Author)
                .Size(12)
                .ForeColor(Color.Gray)
            .End()
            .Row().Content()
                .Label($"{Entity.Content}")
                .Size(12)
                .ForeColor(Color.DarkGreen)
            .End()
        .End()
        .Column(52).Content()
            .ImageLayoutPanel()
            .Binding(this, nameof(Images))
        .End();

        _ = LoadImages();
        return b;
    }

    private async Task LoadImages()
    {
        foreach (var image in Entity.GetImages().Select(i => _imageFileService.GetFullPath(i, CancellationToken.None)))
            _ = AddImage(image);
    }

    public async Task AddImage(Task<PathImageValidObject> pathImageTask)
    {
        var image = await pathImageTask;
        Images.Add(image.LocalPath);
        OnPropertyChanged(nameof(Images));
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}