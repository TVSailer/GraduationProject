using Admin.View.Moduls.UIModel;
using DataAccess.Postgres.Models;
using Logica;

namespace Admin.ViewModels.Lesson
{
    public class ScheduleView : Form
    {
        private List<LessonScheduleEntity> scheduleEntities = new();

        private DataGridView scheduleGrid;
        private ComboBox dayComboBox;
        private DateTimePicker timeStart;
        private DateTimePicker timeEnd;

        public ScheduleView(LessonFieldData instance)
        {
            Text = "Создание расписания";
            Size = new Size(width: 1000, height: 500);
            StartPosition = FormStartPosition.CenterScreen;

            if (instance.Schedule != null)
                scheduleEntities = instance.Schedule;

            CreateControls();

            FormClosed += (s, e) => instance.Schedule = scheduleEntities;
        }

        private void CreateControls()
        {

            dayComboBox = FactoryElements.ComboBox();
            dayComboBox.DataSource = Enum.GetValues(enumType: typeof(Day))
                .Cast<Day>()
                .Select(selector: d => new { Description = d.ToDescriptionString(), Value = d})
                .ToList();

            dayComboBox.DisplayMember = "Description";
            dayComboBox.ValueMember = "Value";
            
            timeStart = FactoryElements.DateTimePicker(custom: CustomFormatDatePicker.HH_mm);
            timeEnd = FactoryElements.DateTimePicker(custom: CustomFormatDatePicker.HH_mm);
            scheduleGrid = FactoryElements.DataGridView();

            scheduleGrid.Columns.Add(columnName: "Day", headerText: "День недели");
            scheduleGrid.Columns.Add(columnName: "Time", headerText: "Время");

            if (scheduleEntities.Count != 0)
                scheduleEntities.ForEach(action: s => scheduleGrid.Rows.Add(values: [s.Day.ToDescriptionString(), $"{s.Start}-{s.End}"]));

            Controls.Add(
                Logica.UILayerPanel.LayoutPanel.CreateColumn()
                    .Row(40, SizeType.Absolute)
                        .Column(dayComboBox.PreferredSize.Width, SizeType.Absolute).ContentEnd(dayComboBox)
                        .Column(timeStart.PreferredSize.Width, SizeType.Absolute).ContentEnd(timeStart)
                        .Column(timeEnd.PreferredSize.Width, SizeType.Absolute).ContentEnd(timeEnd)
                        .Column(150, SizeType.Absolute).ContentEnd(FactoryElements.Button(text: "Добавить", action: AddButton_Click))
                        .Column(150, SizeType.Absolute).ContentEnd(FactoryElements.Button(text: "Удалить", action: DeleteButton_Click))
                        .Column().ContentEnd(new EmptyPanel())
                    .End()
                    .Row().ContentEnd(scheduleGrid)
                    .Build());
        }

        private void AddButton_Click()
        {
            if (string.IsNullOrWhiteSpace(value: dayComboBox.Text) ||
                string.IsNullOrWhiteSpace(value: timeStart.Text) ||
                string.IsNullOrWhiteSpace(value: timeEnd.Text))
            {
                MessageBox.Show(text: "Заполните обязательные поля: день, время");
                return;
            }

            scheduleEntities.Add(item: new LessonScheduleEntity(start: timeStart.HousMinute(), end: timeEnd.HousMinute(), day: (Day)dayComboBox.SelectedValue));
            scheduleGrid.Rows.Add(values: [dayComboBox.Text, $"{timeStart.Text}-{timeEnd.Text}"]);
        }

        private void DeleteButton_Click()
        {
            if (scheduleGrid.SelectedRows.Count > 0)
            {
                var index = scheduleGrid.SelectedRows[index: 0].Index;
                scheduleEntities.RemoveAt(index: index);
                scheduleGrid.Rows.RemoveAt(index: index);
            }
            else
                MessageBox.Show(text: "Выберите строку для удаления");
        }
    }
}
