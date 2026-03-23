using AbstractView.View;
using Admin.DI.Module;
using DataAccess.PostgreSQL.ModelsPrimitive;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.News.Buttons;

public class NewsManagerClicked(
    ControlView controlView) : 
    IButtons<NewsManager>,
    IToolStrip<NewsEntity>, 
    IClicked<NewsEntity>
{
    public InfoToolStrip[] GetToolStrip(CardClickedToolStripArgs<NewsEntity> eventToolStripArgs)
        => [
        ];

    public InfoButton[] GetButtons(ClickedArgs<NewsManager> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            //new InfoButton("Добавить").CommandClick(() => controlView.LoadView<NewsFieldData>()),
        ];

    public InfoButton GetButton(CardClickedArgs<NewsEntity> eventArgs)
        => new InfoButton().CommandClick(() =>
        {
            //controlView.LoadView<NewsFieldData, NewsEntity>(eventArgs.Entity);
        });
}