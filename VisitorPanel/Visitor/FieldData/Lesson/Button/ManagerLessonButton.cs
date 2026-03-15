using DataAccess.PostgreSQL.Models;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.DI.Module;

namespace Visitor.FieldData.Lesson.Button;

public class LessonManagerButtons(ControlView controlView) :  
    IClicked<CardClickedArgs<LessonEntity>>,
    IButtons<ClickedArgs<LessonManager>>
{
    public InfoButton GetButton(CardClickedArgs<LessonEntity> eventArgs) 
        => new InfoButton().CommandClick(
            () => controlView.LoadView<LessonDataUi, LessonEntity>(eventArgs.Entity));

    public InfoButton[] GetButtons(ClickedArgs<LessonManager> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(controlView.UpdateGUI)
        ];
}