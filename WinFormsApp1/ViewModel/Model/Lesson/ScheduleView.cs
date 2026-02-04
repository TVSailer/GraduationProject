using DataAccess.Postgres.Models;
using Logica;
using Layout = Logica.UILayerPanel.Layout;

namespace Admin.ViewModels.Lesson
{
    public class ScheduleView : Form
    {
        private List<LessonScheduleEntity> scheduleEntities = new();

        private DataGridView scheduleGrid;
        private ComboBox dayComboBox;
        private DateTimePicker timeStart;
        private DateTimePicker timeEnd;

        public ScheduleView(List<LessonScheduleEntity>? schedule)
        {
            Text = "Создание расписания";
            Size = new Size(width: 1000, height: 500);
            StartPosition = FormStartPosition.CenterScreen;

            if (schedule != null)
                scheduleEntities = schedule;

            CreateControls();

            //FormClosed += (s, e) => func.Invoke(obj: scheduleEntities);
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
                FactoryElements.TableLayoutPanel()
                .NewRowSize(size: 55)
                .AddingRowsStyles(rowStyles: new RowStyle(sizeType: SizeType.Absolute, height: 40))
                .ControlAddIsColumnAbsolute(control: dayComboBox, weidht: dayComboBox.PreferredSize.Width)
                .ControlAddIsColumnAbsolute(control: timeStart, weidht: timeEnd.PreferredSize.Width)
                .ControlAddIsColumnAbsolute(control: timeEnd, weidht: timeEnd.PreferredSize.Width)
                .ControlAddIsColumnAbsolute(control: FactoryElements.Button(text: "Добавить", action: AddButton_Click), weidht: 150)
                .ControlAddIsColumnAbsolute(control: FactoryElements.Button(text: "Удалить", action: DeleteButton_Click), weidht: 150)
                .ControlAddIsColumnPercent()
                .ControlAddIsRowsPercent(control: scheduleGrid)
                );
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

            scheduleGrid.Rows.Add(values: [dayComboBox.Text, $"{timeStart.Text}-{timeEnd.Text}"]
            );
        }

        private void DeleteButton_Click()
        {
            if (scheduleGrid.SelectedRows.Count > 0)
            {
                //var value = scheduleGrid.SelectedRows[index: 0].Cells[columnName: "Day"].Value;
                var index = scheduleGrid.SelectedRows[index: 0].Index;
                scheduleEntities.RemoveAt(index: index);
                scheduleGrid.Rows.RemoveAt(index: index);
            }
            else
                MessageBox.Show(text: "Выберите строку для удаления");
        }
    }
}
