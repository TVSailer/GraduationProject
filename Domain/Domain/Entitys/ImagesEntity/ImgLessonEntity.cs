using CSharpFunctionalExtensions;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ImagesEntity;

public class ImgLessonEntity : Entity, IImage
{
    [Image] public string? Url { get; set; }
}