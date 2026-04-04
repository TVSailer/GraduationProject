using Admin.ViewModel.Model.Lesson;
using Admin.ViewModel.Model.Lesson.Schedule;
using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;
using Day = Domain.Enum.Day;

namespace Admin.View.Moduls.Lesson.Schedule
{
    public class ScheduleView(ScheduleViewModel viewModel) : Forma<ScheduleViewModel>
    {
        public override void Initialize()
        {
            Text = "Создание расписания";
            Size = new Size(600, 600);
        }

        public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .RowAbsolute(40)
                .Column().Content()
                    .ComboBox()
                    .SetData(viewModel.DayOfWeeks.ToArray<object>(), false)
                    .Binding(viewModel, nameof(viewModel.DayOfWeek))
                .End()
                .Column().Content()
                    .DateTimePicker("HH:mm")
                    .Binding(viewModel, nameof(viewModel.StartTime))
                .End()
                .Column().Content()
                    .DateTimePicker("HH:mm")
                    .Binding(viewModel, nameof(viewModel.EndTime))
                .End()
                .Column().Content()
                    .Button("Добавить")
                    .Command(viewModel.AddSchedule)
                .End()
            .End()
            .Row().Content()
                .CardTableLayoutPanel<LessonScheduleEntity, ScheduleCard>()
                .ContextMenu("Удалить", viewModel.DeleteSchedule)
                .Binding(viewModel, nameof(viewModel.Schedule))
            .End()
            .RowAbsolute(50)
                .ColumnAbsolute(180).Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column()
                .End()
                .ColumnAbsolute(180).Content()
                    .Button("Сохранить")
                    .Command(viewModel.Save)
                .End()
            .End()
        ;
    }
}
