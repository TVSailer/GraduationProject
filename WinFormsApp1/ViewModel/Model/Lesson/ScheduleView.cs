using DataAccess.Postgres.Models;
using Logica;


namespace Admin.ViewModels.Lesson
{
    public class ScheduleView : Form
    {
        private List<ScheduleEntity> scheduleEntities = new();

        private DataGridView scheduleGrid;
        private ComboBox dayComboBox;
        private DateTimePicker timeStart;
        private DateTimePicker timeEnd;

        public ScheduleView(List<ScheduleEntity>? schedule, Action<List<ScheduleEntity>> func)
        {
            Text = "Создание расписания";
            Size = new Size(1000, 500);
            StartPosition = FormStartPosition.CenterScreen;

            if (schedule != null)
                scheduleEntities = schedule;

            CreateControls();

            FormClosed += (s, e) => func.Invoke(scheduleEntities);
        }

        private void CreateControls()
        {

            dayComboBox = FactoryElements.ComboBox();
            dayComboBox.DataSource = Enum.GetValues(typeof(Day))
                .Cast<Day>()
                .Select(d => new { Description = d.ToDescriptionString(), Value = d})
                .ToList();

            dayComboBox.DisplayMember = "Description";
            dayComboBox.ValueMember = "Value";
            
            timeStart = FactoryElements.DateTimePicker(CustomFormatDatePicker.HH_mm);
            timeEnd = FactoryElements.DateTimePicker(CustomFormatDatePicker.HH_mm);
            scheduleGrid = FactoryElements.DataGridView();

            scheduleGrid.Columns.Add("Day", "День недели");
            scheduleGrid.Columns.Add("Time", "Время");

            if (scheduleEntities.Count != 0)
                scheduleEntities.ForEach(s => scheduleGrid.Rows.Add(s.Day.ToDescriptionString(), $"{s.Start}-{s.End}"));

            Controls.Add(
                FactoryElements.TableLayoutPanel()
                .StartNewRowTableAbsolute(55)
                .AddingRowsStyles(new RowStyle(SizeType.Absolute, 40))
                .ControlAddIsColumnAbsolute(dayComboBox, dayComboBox.PreferredSize.Width)
                .ControlAddIsColumnAbsolute(timeStart, timeEnd.PreferredSize.Width)
                .ControlAddIsColumnAbsolute(timeEnd, timeEnd.PreferredSize.Width)
                .ControlAddIsColumnAbsolute(FactoryElements.Button("Добавить", AddButton_Click), 150)
                .ControlAddIsColumnAbsolute(FactoryElements.Button("Удалить", DeleteButton_Click), 150)
                .ControlAddIsColumnPercent()
                .EndTabel()
                .ControlAddIsRowsPercent(scheduleGrid)
                );
        }

        private void AddButton_Click()
        {
            if (string.IsNullOrWhiteSpace(dayComboBox.Text) ||
                string.IsNullOrWhiteSpace(timeStart.Text) ||
                string.IsNullOrWhiteSpace(timeEnd.Text))
            {
                MessageBox.Show("Заполните обязательные поля: день, время и название кружка");
                return;
            }

            scheduleEntities.Add(new ScheduleEntity(timeStart.HousMinute(), timeEnd.HousMinute(), (Day)dayComboBox.SelectedValue));

            scheduleGrid.Rows.Add(
                dayComboBox.Text,
                $"{timeStart.Text}-{timeEnd.Text}"
            );
        }

        private void DeleteButton_Click()
        {
            if (scheduleGrid.SelectedRows.Count > 0)
            {
                var value = scheduleGrid.SelectedRows[0].Cells["Day"].Value;
                var index = scheduleGrid.SelectedRows[0].Index;
                scheduleEntities.RemoveAt(index);
                scheduleGrid.Rows.RemoveAt(index);
            }
            else
                MessageBox.Show("Выберите строку для удаления");
        }
    }
}
