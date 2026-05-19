using Domain.Entitys;
using Domain.Service.FielService.BaseFileService;
using General.Service.File;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiObjects.Card;

namespace Visitor.View.Event;

public class EventCard : ObjectCard<EventEntity>
{
    private readonly IImageFileService _imageFileService;

    public EventCard()
    {
        Size = new Size(300, 450);
        Dock = DockStyle.Top;
        Margin = new Padding(5);

        _imageFileService = new ImageFileService();
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
    => new BuilderLayoutPanel().Column()
            .RowAbsolute(300).Content()
                .Image(_imageFileService.GetFullPath(Entity.UrlTitleImag))
                .BorderStyle(BorderStyle.None)
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
}