using AbstractView.View;
using Admin.FieldData.Model.News;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace Admin.View.Moduls.News;

public class NewsPanelUi<TButtons>(
    TButtons buttons,
    NewsFieldData DataUi,
    CategoryRepository eventCategoryRepository) : UiView
    where TButtons : IButtons<NewsFieldData>
{
    const int SizeRow = 5;
    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
    {
        return layout.ObjectBinding(DataUi).Column()
            .Row()
            .Column()
            .Row(SizeRow).LabelTextBox("Название: ", "Введите название", nameof(NewsFieldData.Title))
            .Row(SizeRow).LabelDatePicker("Дата:", "dd.MM.yyyy HH:mm", nameof(NewsFieldData.Date))
            //.Row(SizeRow).LabelComboBox("Категория: ", nameof(LessonFieldData.Category), eventCategoryRepository.Get())
            .Row(SizeRow).LabelTextBox("Автор:", "Введите автора", nameof(NewsFieldData.Author))
            .Row(80).LabelTextBoxMultiline("Описание: ", "Введите описание", nameof(NewsEntity.Content))
            .End()
            .Column()
            .RowAutoSize().Content().Label("📷 Изображения:").End()
            .Row().Content().ImageLayoutPanel(DataUi.RepositoryImgEntity).End()
            .End()
            .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(buttons.GetButtons(new ClickedArgs<NewsFieldData>(DataUi))).End();
    }
}