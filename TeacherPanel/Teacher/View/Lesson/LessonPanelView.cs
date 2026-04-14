using Domain.Entitys;
using Teacher.View.Lesson.Shedule;
using Teacher.View.Review;
using Teacher.ViewModel.Lesson;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Teacher.View.Lesson;
public class LessonPanelView(LessonPanelViewModel viewModel) : UiView<LessonPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
    {
        return builderLayoutPanel.Column()
            .Row()
                .Column(25)
                    .RowAutoSize().Content()
                        .Label(viewModel.Title)
                        .Size(18)
                        .Alignment(ContentAlignment.TopCenter)
                        .ForeColor(Color.DarkBlue)
                    .End()
                    .RowAutoSize().Content()
                        .Label($"{viewModel.Teacher} | {viewModel.Teacher.NumberPhone}")
                        .ForeColor(Color.Black)
                        .BorderStyle(BorderStyle.FixedSingle)
                        .Size(12)
                    .End()
                    .RowAutoSize().Content()
                        .Label("Расписание")
                        .Size(12)
                        .Alignment(ContentAlignment.TopCenter)
                    .End()
                    .Row(15).Content()
                        .CardTableLayoutPanel<LessonScheduleEntity, ScheduleCard>()
                        .Binding(viewModel, nameof(viewModel.Schedule))
                    .End()
                    .Row(85).Content()
                        .Label(viewModel.Description)
                        .BorderStyle(BorderStyle.FixedSingle)
                        .Size(12)
                    .End()
                .End()
                .Column(55).Content()
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

