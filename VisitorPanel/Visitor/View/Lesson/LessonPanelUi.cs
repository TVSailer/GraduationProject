using CSharpFunctionalExtensions;
using DataAccess.PostgreSQL.Models;
using Extension_Func_Library;
using UserInterface.GenericEntity;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel;
using UserInterface.UiLayoutPanel.ImagePanel;
using UserInterface.View;
using Visitor.FieldData.Lesson;

namespace Visitor.View.Lesson;

public class LessonPanelUi : UiView<LessonDataUi, LessonEntity>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
    {
        var entity = DataUi.Entity;
        return builderLayoutPanel.Row()
            .Column()
                .RowAutoSize().Content()
                    .Label(entity.Name)
                    .Size(18)
                    .Alignment(ContentAlignment.TopCenter)
                    .ForeColor(Color.DarkBlue)
                    .End()
                .RowAutoSize().Content()
                    .LinkLabel($"★ {entity.Rating()} • {entity.Reviews.Count} отзывов")
                    .Size(12)
                    .Color(Color.Orange)
                    .End()
                .RowAutoSize().Content()
                    .LinkLabel(entity.Teacher.FIO.ToString())
                    .Color(Color.Black)
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
                    .TextBox()
                    .Text(entity.Description)
                    .Multiline()
                    .ReadOnly()
                    .Size(12)
                .End()
            .End()
            .Column()
                .Row().ContentEnd(new ImageLayoutPanel(DataUi.RepositoryImgEntity))
            .End();
    }
}