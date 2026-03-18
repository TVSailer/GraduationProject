using DataAccess.PostgreSQL.Models;
using Extension_Func_Library;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.FieldData.Lesson;
using Visitor.FieldData.Lesson.Button;
using Visitor.View.Review;

namespace Visitor.View.Lesson;
public class LessonPanelUi(LessonButton button) : UiView<LessonDataUi, LessonEntity>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
    {
        var entity = DataUi.Entity;
        return builderLayoutPanel.Column()
            .Row()
                .Column(20)
                    .RowAutoSize().Content()
                        .Label(entity.Name)
                        .Size(18)
                        .Alignment(ContentAlignment.TopCenter)
                        .ForeColor(Color.DarkBlue)
                    .End()
                    .RowAutoSize().Content()
                        .Label($"{entity.Teacher.FIO} | {entity.Teacher.NumberPhone}")
                        .ForeColor(Color.Black)
                        .Size(12)
                    .End()
                    .RowAutoSize().Content()
                        .Label("Расписание")
                        .Size(12)
                        .Alignment(ContentAlignment.TopCenter)
                    .End()
                    .With(c => entity.Schedule.ForEach(
                            s => c.RowAutoSize().Content()
                                .Label(s.ToString())
                                .Size(12)
                                .End()))
                    .Row().Content()
                        .TextBox(entity.Description)
                        .Multiline()
                        .ReadOnly()
                        .Size(12)
                    .End()
                .End()
                .Column(40)
                    .Row().Content()
                        .ImageLayoutPanel(DataUi.RepositoryImgEntity)
                    .End()
                .End()
                .Column(40)
                    .Row().Content()
                        .CardTableLayoutPanel<ReviewEntity, ReviewCard>(entity.Reviews.ToArray())
                    .End()
                .End()
            .End()
            .RowAbsolute(80).Content().ButtonLayoutPanel(button.GetButtons(new ClickedArgs<LessonEntity>(entity))).End();
    }
}