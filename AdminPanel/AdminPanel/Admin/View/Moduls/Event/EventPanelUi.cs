using Admin.FieldData.Model.Event;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.ImagePanel;
using UserInterface.View;

namespace Admin.View.Moduls.Event;

public class EventPanelUi<TButtons>(
    EventRepository teacherRepository,
    TButtons buttons,
    CategoryRepository eventCategoryRepository) : UiView<EventFieldData, EventEntity>
    where TButtons : IButtons<EventFieldData>
{
    const int SizeRow = 5;
    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
    {
        return layout.ObjectBinding(DataUi).CreateColumn()
            .Row()
                .Column()
                    .Row(SizeRow).LabelTextBox("Название: ", "Введите название", nameof(EventFieldData.Title))
                    .Row(SizeRow).LabelDatePicker("Дата:", "dd.MM.yyyy", nameof(EventFieldData.Date))
                    .Row(SizeRow).LabelDatePicker("Начало:", "HH:mm", nameof(EventFieldData.Start))
                    .Row(SizeRow).LabelDatePicker("Конец", "HH:mm", nameof(EventFieldData.End))
                    .Row(SizeRow).LabelComboBox("Категория: ", nameof(EventFieldData.Category), eventCategoryRepository.Get())
                    .Row(SizeRow).LabelTextBox("Место: ", "Введите место проведения", nameof(EventFieldData.Location))
                    .Row(SizeRow).LabelTextBox("Ссылка на регистрацию: ", "Введите ссылку на регистрацию", nameof(EventFieldData.RegisLink))
                    .Row(SizeRow).LabelTextBox("Организатор: ", "Введите фио организатора", nameof(EventFieldData.Organizer))
                    .Row(SizeRow).LabelNumeric("Кол. участников: ", nameof(EventFieldData.MaxParticipants))
                    .Row(80).LabelTextBoxMultiline("Описание: ", "Введите описание", nameof(EventFieldData.Description))
                .End()
                .Column()
                    .RowAutoSize().Content().Label("📷 Изображения:").End()
                    .Row().ContentEnd(new ImageLayoutPanel(DataUi.RepositoryImgEntity))
                .End()
            .End()
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(buttons.GetButtons(DataUi)));
    }
}