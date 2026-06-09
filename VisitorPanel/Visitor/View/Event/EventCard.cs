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

namespace Visitor.View.Event;

public class EventCard : ObjectCard<EventEntity>, INotifyPropertyChanged
{
    private readonly IImageFileService _imageFileService;
    public string Image { get; set; }

    public EventCard()
    {
        Size = new Size(300, 450);
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
        var b = new BuilderLayoutPanel().Column()
            .RowAbsolute(300).Content()
                .Image()
                .BorderStyle(BorderStyle.None)
                .Binding(this, nameof(Image))
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Title)
                .Size(14)
                .ForeColor(Color.DarkBlue)
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Schedule.ToString())
                .Size(12)
                .ForeColor(Color.Gray)
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Location)
                .Size(12)
                .ForeColor(Color.Gray)
            .End()
                .RowAutoSize().Content()
                .Label($"{Entity.Organizer}")
                .Size(12)
                .ForeColor(Color.DarkGreen)
            .End();

        _ = AddImage(_imageFileService.GetFullPath(Entity.UrlTitleImag, CancellationToken.None));

        return b;
    }

    public async Task AddImage(Task<PathImageValidObject> pathImageTask)
    {
        var path = await pathImageTask;
        Image = path.LocalPath;
        OnPropertyChanged(nameof(Image));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}