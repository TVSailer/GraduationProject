using Admin.ViewModel.Model.Event;
using Domain.Entitys;
using Domain.Repository;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Admin.View.Moduls.Event;

public class EventDetailsPanelUi(
    EventAddingPanelViewModel DataUi,
    IRepository<CategoryEntity> eventCategoryRepository) : UiView<EventEntity>
{
    const int SizeRow = 5;

    public override IBuilder CreateUi(BuilderLayoutPanel layout)
    {
        return layout.ObjectBinding(DataUi).Column()
            .Row()
            .Column()
            .Row(SizeRow).LabelTextBox("Название: ", "Введите название", nameof(EventAddingPanelViewModel.Title))
            //.Row(SizeRow).LabelDatePicker("Дата:", "dd.MM.yyyy", nameof(EventFieldData.Date))
            //.Row(SizeRow).LabelDatePicker("Начало:", "HH:mm", nameof(EventFieldData.Start))
            //.Row(SizeRow).LabelDatePicker("Конец", "HH:mm", nameof(EventFieldData.End))
            //.Row(SizeRow).LabelComboBox("Категория: ", nameof(EventFieldData.Category), eventCategoryRepository.Get())
            //.Row(SizeRow).LabelTextBox("Место: ", "Введите место проведения", nameof(EventFieldData.Location))
            //.Row(SizeRow).LabelTextBox("Ссылка на регистрацию: ", "Введите ссылку на регистрацию", nameof(EventFieldData.RegisLink))
            //.Row(SizeRow).LabelTextBox("Организатор: ", "Введите фио организатора", nameof(EventFieldData.Organizer))
            .Row(80).LabelTextBoxMultiline("Описание: ", "Введите описание", nameof(EventAddingPanelViewModel.Description))
            .End()
            //.Column()
            //    .RowAutoSize().Content().Label("📷 Изображения:").End()
            //    .Row().ContentEnd(new ImageLayoutPanel(DataUi.RepositoryImgEntity))
            //.End()
            .End();
        //.Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(buttons.GetButtons(new ClickedArgs<EventFieldData>(DataUi))).End();
    }
}