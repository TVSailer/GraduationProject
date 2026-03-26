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

    public NewsEntity() { }

    public NewsEntity(string title, string content, string date, CategoryEntity category, string author)
    {
        Title = title;
        Content = content;
        Date = date;
        Category = category;
        Author = author;
    }

    public override string ToString() => $"Новость: {Title} {Date}";
    public DateTime DateT() => DateTime.Parse(Date);
}
