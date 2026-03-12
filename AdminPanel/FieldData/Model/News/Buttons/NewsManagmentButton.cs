using Admin.DI;
using Admin.DI.Module;
using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.News.Buttons;

public class NewsManagerClicked(
    ControlView controlView) : 
    IButtons<NewsManager>,
    IButtons<CardClickedToolStripArgs<NewsEntity>>, 
    IClicked<CardClickedArgs<NewsEntity>>
{
    public List<InfoButton> GetButtons(CardClickedToolStripArgs<NewsEntity> eventToolStripArgs)
        => [
        ];

    public List<InfoButton> GetButtons(NewsManager eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить").CommandClick(() => controlView.LoadView<NewsFieldData>()),
        ];

    public InfoButton GetButton(CardClickedArgs<NewsEntity> eventArgs)
        => new InfoButton().CommandClick(() =>
        {
            controlView.LoadView<NewsFieldData, NewsEntity>(eventArgs.Entity);
        });
}