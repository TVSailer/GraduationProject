using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class NewsEntity : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Date { get; set; }

    [ForeignKey(name: nameof(NewsCategoryEntity))]
    public long CategoryId { get; set; }
    public NewsCategoryEntity Category { get; set; }

    public string Author { get; set; }
    public List<ImgNewsEntity>? Imgs { get; set; } = new();
    
    public override string ToString() => $"Новость: {Title} {Date}";
    public DateTime DateT() => DateTime.Parse(Date);
}
