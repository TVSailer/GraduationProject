using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class NewsEntity : Entity
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Date { get; private set; }


    [ForeignKey(nameof(NewsCategoryEntity))]
    public long idCategory { get; private set; }
    public NewsCategoryEntity Category { get; private set; }

    public string Author { get; private set; }
    public List<ImgNewsEntity>? Imgs { get; set; } = new();
    
    public NewsEntity() { }

    public NewsEntity(
        string title, 
        string content, 
        string date, 
        NewsCategoryEntity category, 
        string author, List<ImgNewsEntity> imgs) 
    {
        Title = title;
        Content = content;
        Date = date;
        Category = category;
        Author = author;
        Imgs = imgs;
    }

    public override string ToString()
        => $"Новость: {Title} {Date}";
}
