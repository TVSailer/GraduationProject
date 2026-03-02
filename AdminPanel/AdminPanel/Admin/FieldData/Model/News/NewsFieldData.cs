using Admin.ViewModel.AbstractFieldData;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Models.Imgs;
using DataAccess.Postgres.Repository;
using UserInterface.Attribute;
using Validaiger.AttributeValid;

namespace Admin.FieldData.Model.News;


public class NewsFieldData(CategoryRepository repository) : FieldDataWithImages<ImgNewsEntity, NewsEntity>
{
    [LinkingEntity(nameof(NewsEntity.Imgs))]
    public List<ImgNewsEntity> Images
    {
        get => ImagesData;
        set => ImagesData = value;
    }

    public List<CategoryEntity> Categorys => repository.Get();

    [RequiredCustom]
    [LinkingEntity(nameof(NewsEntity.Category))]
    public CategoryEntity? Category { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(NewsEntity.Title))]
    public string? Title { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(NewsEntity.Content))]
    public string? Content { get; set => ValidProperty(ref field, value); }

    [LinkingEntity(nameof(NewsEntity.Date))]
    public string? Date
    {
        get;
        set => ValidProperty(ref field, value);
    } = DateTime.Now.ToString();

    [RequiredCustom]
    [LinkingEntity(nameof(NewsEntity.Author))]
    public string? Author { get; set => ValidProperty(ref field, value); }
}