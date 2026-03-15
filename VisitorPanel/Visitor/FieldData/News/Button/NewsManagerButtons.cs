using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.DI.Module;

namespace Visitor.FieldData.News.Button;

public class NewsManagerButtons(ControlView controlView) :  
    IButtons<NewsManager>
{
    public InfoButton[] GetButtons(ClickedArgs<NewsManager> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(controlView.UpdateGUI)
        ];
}