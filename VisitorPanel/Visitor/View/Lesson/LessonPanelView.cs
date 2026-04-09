using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;
using Visitor.View.Lesson.Shedule;
using Visitor.View.Review;
using Visitor.ViewModel.Lesson;

namespace Visitor.View.Lesson;
public class LessonPanelView(LessonPanelViewModel viewModel) : UiView<LessonPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
    {
        return builderLayoutPanel.Column()
            .Row()
                .Column(20)
                    .RowAutoSize().Content()
                        .Label(viewModel.Title)
                        .Size(18)
                        .Alignment(ContentAlignment.TopCenter)
                        .ForeColor(Color.DarkBlue)
                    .End()
                    .RowAutoSize().Content()
                        .Label($"{viewModel.Teacher} | {viewModel.Teacher.NumberPhone}")
                        .ForeColor(Color.Black)
                        .Size(12)
                    .End()
                    .RowAutoSize().Content()
                        .Label("Расписание")
                        .Size(12)
                        .Alignment(ContentAlignment.TopCenter)
                    .End()
                    .RowAutoSize().Content()
                        .CardTableLayoutPanel<LessonScheduleEntity, ScheduleCard>()
                    .End()
                    .Row().Content()
                        .TextBox(viewModel.Description)
                        .Multiline()
                        .ReadOnly()
                        .Size(12)
                    .End()
                .End()
                .Column(60).Content()
                    .ImageLayoutPanel()
                    .RefreshImages(viewModel.Images)
                .End()
                .Column(20).Content()
                    .CardTableLayoutPanel<ReviewEntity, ReviewCard>()
                    .Initialize(viewModel.ReviewEntites)
                .End()
            .End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column().Content()
                    .Button("Добавить комментарий")
                    .Command(viewModel.AddComment)
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
                .End()
            .End();
    }
}

