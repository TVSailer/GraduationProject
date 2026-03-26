using CSharpFunctionalExtensions;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ImagesEntity;

public class ImageLessonEntity : Entity, IImage
{
    public string? Url { get; set; }
}