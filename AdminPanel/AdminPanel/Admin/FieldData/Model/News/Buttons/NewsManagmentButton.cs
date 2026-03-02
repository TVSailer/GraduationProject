using Admin.DI;
using Admin.DI.Module;
using DataAccess.Postgres.Models;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.News.Buttons;

public class NewsManagerButton(
    ControlView controlView) : 
    IButtons<NewsManager>,
    IButtons<CardClickedToolStripArgs<NewsEntity>>, 
    IButton<CardClickedArgs<NewsEntity>>
{
    public List<CustomButton> GetButtons(CardClickedToolStripArgs<NewsEntity> eventToolStripArgs)
        => [
        ];

    public List<CustomButton> GetButtons(NewsManager eventArgs)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Добавить").CommandClick(() => controlView.LoadView<NewsFieldData>()),
        ];

    public CustomButton GetButton(CardClickedArgs<NewsEntity> eventArgs)
        => new CustomButton().CommandClick(() =>
        {
            controlView.LoadView<NewsFieldData, NewsEntity>(eventArgs.Entity);
        });
}