using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Models;

public class NewsEntity : Entity
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Date { get; private set; }
    public string Category { get; private set; }
    public string Author { get; private set; }
    public List<ImgNewsEntity>? ImgsNews { get; set; } = new();
    
    public NewsEntity() { }

    public NewsEntity(string title, string content, string date, string category, string author, List<ImgNewsEntity> imgs) 
    {
        Title = title;
        Content = content;
        Date = date;
        Category = category;
        Author = author;
        ImgsNews = imgs;
    }

    public override string ToString()
        => $"Новость: {Title} {Date}";
}
