using CSharpFunctionalExtensions;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ImagesEntity;

public class ImageNewsEntity : Entity, IImage
{
    public string? Url { get; set; }
}

