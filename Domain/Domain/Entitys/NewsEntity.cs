using System.Data;
using CSharpFunctionalExtensions;
using Domain.Entitys.ImagesEntity;
using Domain.ValidObject;

namespace Domain.Entitys;

public class NewsEntity : Entity
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Date { get; private set; }
    public CategoryEntity Category { get; private set; }
    public string Author { get; private set; }
    public ICollection<ImageNewsEntity> Images { get; private set; } = [];

    private NewsEntity() { }

    public NewsEntity(
        TitleValidObject title,
        DescriptionValidObject content,
        DateOnly date,
        CategoryEntity category,
        AuthorValidObject author,
        IEnumerable<string> images)
    {
        Title = title.Text;
        Content = content.Text;
        Author = author.Text;
        Date = date.ToString("dd.MM.yyyy");
        Category = category;
        UpdateImages(images);
    }

    public NewsEntity UpdateTitle(TitleValidObject title)
    {
        Title = title.Text;
        return this;
    }
    
    public NewsEntity UpdateAuthor(AuthorValidObject author)
    {
        Author = author.Text;
        return this;
    }

    public NewsEntity UpdateContent(DescriptionValidObject description)
    {
        Content = description.Text;
        return this;
    }
    
    public NewsEntity UpdateDate(DateOnly date)
    {
        Date = date.ToString("dd.MM.yyyy");
        return this;
    }

    public NewsEntity UpdateCategory(CategoryEntity category)
    {
        Category = category;
        return this;
    }

    public override string ToString() => $"Новость: {Title} {Date}";

    public void UpdateImages(IEnumerable<string>? images)
    {
        if (images is null) return;
        Images = images.Select(i => new ImageNewsEntity(new ImageValidObject(i))).ToList();
    }

    public IEnumerable<string> GetImages()
        => Images.Select(i => i.Url);

    public bool Include(string category, string title, string startDate, string endDate)
    {
        return (string.IsNullOrEmpty(category) || category.Equals(Category.Category)) &&
               Title.StartsWith(title ?? "") &&
               DateTime.Parse(Date) >= (DateTime.TryParse(startDate, out var dateS) ? dateS : DateTime.MinValue) &&
               DateTime.Parse(Date) <= (DateTime.TryParse(endDate, out var dateE) ? dateE : DateTime.MaxValue);
    }
}
