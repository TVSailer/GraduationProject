using Admin.FieldData.Model.News;
using Admin.ViewModel.Model.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.ImagePanel;
using UserInterface.View;

namespace Admin.View.Moduls.News;

public class NewsPanelUi<TButtons>(
    NewsRepository teacherRepository,
    TButtons buttons,
    CategoryRepository eventCategoryRepository) : UiView<NewsFieldData, NewsEntity>
    where TButtons : IButtons<NewsFieldData>
{
    const int SizeRow = 5;
    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
    {
        return layout.ObjectBinding(DataUi).CreateColumn()
            .Row()
            .Column()
            .Row(SizeRow).LabelTextBox("Название: ", "Введите название", nameof(NewsFieldData.Title))
            .Row(SizeRow).LabelDatePicker("Дата:", "dd.MM.yyyy HH:mm", nameof(NewsFieldData.Date))
            .Row(SizeRow).LabelComboBox("Категория: ", nameof(LessonFieldData.Category), eventCategoryRepository.Get())
            .Row(SizeRow).LabelTextBox("Автор:", "Введите автора", nameof(NewsFieldData.Author))
            .Row(80).LabelTextBoxMultiline("Описание: ", "Введите описание", nameof(NewsEntity.Content))
            .End()
            .Column()
            .RowAutoSize().Content().Label("📷 Изображения:").End()
            .Row().ContentEnd(new ImageLayoutPanel(DataUi.RepositoryImgEntity))
            .End()
            .End()
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(buttons.GetButtons(DataUi)));
    }
}