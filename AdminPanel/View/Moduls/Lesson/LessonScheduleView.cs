using Admin.ViewModel.Model.Lesson;
using DataAccess.PostgreSQL.Models;
using ExtensionFunc;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel;
using Day = DataAccess.PostgreSQL.Enum.Day;

namespace Admin.View.Moduls.Lesson
{
    public class LessonScheduleView : Form
    {
        private readonly List<LessonScheduleEntity> _scheduleEntities;

        private DataGridView _scheduleGrid;
        private ComboBox _dayComboBox;
        private DateTimePicker _timeStart;
        private DateTimePicker _timeEnd;

        public LessonScheduleView(LessonFieldData? instance)
        {
            if (instance is null) throw new ArgumentNullException();
            Text = "Создание расписания";
            Size = new Size(width: 1100, height: 500);
            StartPosition = FormStartPosition.CenterScreen;

            if (instance.Schedule != null)
                _scheduleEntities = instance.Schedule;

            CreateControls();

            FormClosed += (s, e) => instance.Schedule = _scheduleEntities;
        }

        private void CreateControls()
        {

            _dayComboBox = FactoryElements.ComboBox();
            _dayComboBox.DataSource = Enum.GetValues(enumType: typeof(Day))
                .Cast<Day>()
                .Select(selector: d => new { Description = d.ToDescriptionString(), Value = d})
                .ToList();

            _dayComboBox.DisplayMember = "Description";
            _dayComboBox.ValueMember = "Value";
            
            _timeStart = FactoryElements.DateTimePicker(custom: "HH:mm");
            _timeEnd = FactoryElements.DateTimePicker(custom: "HH:mm");

            _scheduleGrid = FactoryElements.DataGridView();

            _scheduleGrid.Columns.Add(columnName: "Day", headerText: "День недели");
            _scheduleGrid.Columns.Add(columnName: "Time", headerText: "Время");

            if (_scheduleEntities.Count != 0)
                _scheduleEntities.ForEach(action: s => _scheduleGrid.Rows.Add(values: [s.Day.ToDescriptionString(), $"{s.Start}-{s.End}"]));

            Controls.Add(
                new BuilderLayoutPanel().Column()
                    .Row(55, SizeType.Absolute)
                        .Column()
                            .Row()
                                .Column(_dayComboBox.PreferredSize.Width + 55, SizeType.Absolute).ContentEnd(_dayComboBox)
                                .Column(_timeStart.PreferredSize.Width, SizeType.Absolute).ContentEnd(_timeStart)
                                .Column(_timeEnd.PreferredSize.Width, SizeType.Absolute).ContentEnd(_timeEnd)
                                .Column(150, SizeType.Absolute).ContentEnd(FactoryElements.Button(text: "Добавить", action: AddButton_Click))
                                .Column(150, SizeType.Absolute).ContentEnd(FactoryElements.Button(text: "Удалить", action: DeleteButton_Click))
                                .Column(150, SizeType.Absolute).ContentEnd(FactoryElements.Button(text: "Сохранить", action: Close))
                                .Column().ContentEnd(new EmptyPanel())
                            .End()
                        .End()
                    .End()
                    .Row(99).ContentEnd(_scheduleGrid)
                    .Build());
        }

        private void AddButton_Click()
        {
            if (string.IsNullOrWhiteSpace(value: _dayComboBox.Text) ||
                string.IsNullOrWhiteSpace(value: _timeStart.Text) ||
                string.IsNullOrWhiteSpace(value: _timeEnd.Text))
            {
                MessageBox.Show(text: "Заполните обязательные поля: день, время");
                return;
            }

            _scheduleEntities.Add(item: new LessonScheduleEntity(start: _timeStart.HousMinute(), end: _timeEnd.HousMinute(), day: (Day)_dayComboBox.SelectedValue));
            _scheduleGrid.Rows.Add(values: [_dayComboBox.Text, $"{_timeStart.Text}-{_timeEnd.Text}"]);
        }

        private void DeleteButton_Click()
        {
            if (_scheduleGrid.SelectedRows.Count > 0)
            {
                var index = _scheduleGrid.SelectedRows[index: 0].Index;
                _scheduleEntities.RemoveAt(index: index);
                _scheduleGrid.Rows.RemoveAt(index: index);
            }
            else
                MessageBox.Show(text: "Выберите строку для удаления");
        }
    }
}
