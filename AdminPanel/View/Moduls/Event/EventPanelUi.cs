using Admin.FieldData.Model.Event;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.UiLayoutPanel.ImagePanel;
using UserInterface.View;

namespace Admin.View.Moduls.Event;

public class EventPanelUi<TButtons>(
    TButtons buttons,
    CategoryRepository eventCategoryRepository) : UiView<EventFieldData, EventEntity>
    where TButtons : IButtons<EventFieldData>
{
    const int SizeRow = 5;
    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
    {
        return layout.ObjectBinding(DataUi).Column()
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
                    .Row(80).LabelTextBoxMultiline("Описание: ", "Введите описание", nameof(EventFieldData.Description))
                .End()
                .Column()
                    .RowAutoSize().Content().Label("📷 Изображения:").End()
                    .Row().ContentEnd(new ImageLayoutPanel(DataUi.RepositoryImgEntity))
                .End()
            .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(buttons.GetButtons(new ClickedArgs<EventFieldData>(DataUi))).End();
    }
}