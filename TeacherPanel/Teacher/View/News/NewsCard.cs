using Domain.Entitys;
using Domain.Service.FielService.BaseFileService;
using General.Service.File;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiObjects.Card;

namespace Teacher.View.News;

public class NewsCard : ObjectCard<NewsEntity>
{
    private readonly IImageFileService _imageFileService;

    public NewsCard()
    {
        Height = 500;
        Dock = DockStyle.Top;
        Margin = new Padding(5);

        _imageFileService = new ImageFileService();
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Row()
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
                .RefreshImages(Entity.GetImages().Select(i => _imageFileService.GetFullPath(i)))
            .End();

}