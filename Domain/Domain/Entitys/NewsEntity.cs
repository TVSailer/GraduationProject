using CSharpFunctionalExtensions;
using Domain.Entitys.ImagesEntity;

namespace Domain.Entitys;

public class NewsEntity : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Date { get; set; }
    public CategoryEntity Category { get; set; }
    public string Author { get; set; }
    public ICollection<ImageNewsEntity> Images { get; set; } = [];

    private NewsEntity() { }

    public NewsEntity(string title, string content, string date, CategoryEntity category, string author)
    {
        Title = title;
        Content = content;
        Date = date;
        Category = category;
        Author = author;
    }
    public NewsEntity(string title, string content, string date, CategoryEntity category, string author, IEnumerable<string> images)
    {
        Title = title;
        Content = content;
        Date = date;
        Category = category;
        Author = author;
        SetImages(images);
    }

    public override string ToString() => $"Новость: {Title} {Date}";
    public DateTime DateT() => DateTime.Parse(Date);

    public void SetImages(IEnumerable<string> images)
        => Images = images.Select(i => new ImageNewsEntity { Url = i }).ToList();

    public IEnumerable<string> GetImages()
        => Images.Select(i => i.Url);

}
