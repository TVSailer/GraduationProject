using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;
using DataAccess.PostgreSQL.Models.Imgs;

namespace DataAccess.PostgreSQL.Models;

public class NewsEntity : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Date { get; set; }

    [ForeignKey(nameof(CategoryEntity))]
    public long CategoryId { get; set; }
    public CategoryEntity Category { get; set; }

    public string Author { get; set; }
    public List<ImgNewsEntity> Imgs { get; set; } = [];
    
    public override string ToString() => $"Новость: {Title} {Date}";
    public DateTime DateT() => DateTime.Parse(Date);
}
