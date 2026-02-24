using Admin.ViewModel.AbstractFieldData;
using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.CustomAttribute;
using WinFormsApp1.ViewModelEntity.Event;

namespace Admin.ViewModel.Model.News;


public class NewsFieldData(NewsCategoryRepository repository) : FieldModelWithImages<NewsEntity>
{
    public List<NewsCategoryEntity> Categorys => repository.Get();

    [RequiredCustom]
    [LinkingEntity(nameof(NewsEntity.Category))]
    [ComboBoxFieldUi("Категория:", nameof(Categorys))]
    public NewsCategoryEntity Category { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(NewsEntity.Title))]
    [BaseFieldUi("Название:", "Введите название")]
    public string? Title { get; set => 
        ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(NewsEntity.Content))]
    [MultilineFieldUi]
    public string? Content { get; set => ValidProperty(ref field, value); }

    [LinkingEntity(nameof(NewsEntity.Date))]
    [DateFieldUi("Дата:", "dd.MM.yyyy HH:mm")]
    public string? Date
    {
        get;
        set => ValidProperty(ref field, value);
    } = DateTime.Now.ToString();

    [RequiredCustom]
    [LinkingEntity(nameof(NewsEntity.Author))]
    [BaseFieldUi("Автор:", "Введите автора")]
    public string Location { get; set => ValidProperty(ref field, value); }
}